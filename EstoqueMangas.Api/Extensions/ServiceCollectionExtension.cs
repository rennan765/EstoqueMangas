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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EstoqueMangas.Api.Extensions
{
    /// <summary>
    /// Classe para implementar os métodos de extensão de configuração dos serviços.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Configuração do contexto
        /// </summary>
        public static IServiceCollection ConfigurarContexto(this IServiceCollection services)
        {
            //Adiciona o contexto
            services.AddDbContext<EstoqueMangasContext>(options => options.UseMySql(new ConnectionStrings().MySql()));

            return services;
        }

        /// <summary>
        /// Configuração dos serviços
        /// </summary>
        public static IServiceCollection ConfigurarAcessorDeContexto(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        /// <summary>
        /// Configuração dos serviços
        /// </summary>
        public static IServiceCollection ConfigurarServicos(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IServiceUsuario, ServiceUsuario>()
                .AddTransient<IServiceEditora, ServiceEditora>()
                .AddTransient<IServiceAutor, ServiceAutor>();

            return services;
        }

        /// <summary>
        /// Configuração dos repositórios
        /// </summary>
        public static IServiceCollection ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>()
                .AddTransient<IRepositoryAutor, RepositoryAutor>()
                .AddTransient<IRepositoryManga, RepositoryManga>()
                .AddTransient<IRepositoryAutorManga, RepositoryAutorManga>()
                .AddTransient<IRepositoryEdicao, RepositoryEdicao>()
                .AddTransient<IRepositoryEditora, RepositoryEditora>();

            return services;
        }

        /// <summary>
        /// Configuração do token
        /// </summary>
        public static IServiceCollection ConfigurarToken(this IServiceCollection services, string audience, string issuer)
        {
            //Configuração do Token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            {
                Audience = audience,
                Issuer = issuer,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString(CultureInfo.InvariantCulture))

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
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }

        /// <summary>
        /// Configuração do Swagger
        /// </summary>
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            //Aplicando documentação com swagger
            services.AddSwaggerGen(x =>
            {
                //Dados da documentação
                x.SwaggerDoc("v1",
                             new Info
                             {
                                 Title = "EstoqueMangas",
                                 Version = "v1",
                                 Description = "Projeto para controle de estoque de mangás.",
                                 Contact = new Contact
                                 {
                                     Name = "Rennan Rezende",
                                     Email = "rennan765@gmail.com",
                                     Url = "https://github.com/rennan765"
                                 }
                             });

                //Inserir token

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                x.AddSecurityDefinition("Bearer",
                                        new ApiKeyScheme
                                        {
                                            In = "header",
                                            Description = "Autenticação baseada em Json Web Token (JWT)",
                                            Name = "Authorization",
                                            Type = "apiKey"
                                        });

                x.AddSecurityRequirement(security);

                //Inserir XML de comentários
                var xmlDocumentPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    x.IncludeXmlComments(xmlDocumentPath);
                }
            });

            return services;
        }
    
        /// <summary>
        /// Configuração do MVC
        /// </summary>
        public static IServiceCollection ConfigurarMvc(this IServiceCollection services)
        {
            //Para todas as requisições serem necessaria o token, para um endpoint não exisgir o token
            //deve colocar o [AllowAnonymous]
            //Caso remova essa linha, para todas as requisições que precisar de token, deve colocar
            //o atributo [Authorize("Bearer")]
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            return services;
        }
    }
}
