using System;
using EstoqueMangas.Api.Security;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Domain.Services;
using EstoqueMangas.Infra.Persistence;
using EstoqueMangas.Infra.Persistence.Repositories;
using EstoqueMangas.Infra.Transactions;
using EstoqueMangas.Shared.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EstoqueMangas.Api
{
    public class Startup
    {
        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adiciona o contexto
            services.AddDbContext<EstoqueMangasContext>(options => options.UseMySql(ConnectionStrings.MySQL()));

            //Adiciona a injeção de dependencia
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddTransient<IServiceUsuario, ServiceUsuario>();

            //Repositories
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>()
                .AddTransient<IRepositoryAutor, RepositoryAutor>()
                .AddTransient<IRepositoryManga, RepositoryManga>()
                .AddTransient<IRepositoryAutorManga, RepositoryAutorManga>()
                .AddTransient<IRepositoryEdicao, RepositoryEdicao>()
                .AddTransient<IRepositoryEditora, RepositoryEditora>();

            //Configuração do Token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())

            };

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //Para todas as requisições serem necessaria o token, para um endpoint não exisgir o token
            //deve colocar o [AllowAnonymous]
            //Caso remova essa linha, para todas as requisições que precisar de token, deve colocar
            //o atributo [Authorize("Bearer")]
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddCors();

            //Aplicando documentação com swagger
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new Info { Title = "EstoqueMangas", Version = "v1" });
                x.OperationFilter<AddRequiredHeaderParameter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => 
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstoqueMangas - V1");
            });

        }
    }
}
