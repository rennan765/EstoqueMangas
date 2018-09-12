﻿using EstoqueMangas.Api.Extensions;
using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Domain.Services;
using EstoqueMangas.Infra.Persistence;
using EstoqueMangas.Infra.Persistence.Repositories;
using EstoqueMangas.Infra.Transactions;
using EstoqueMangas.Shared.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.Api
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        #region Atributos
        private const string ISSUER = "c1f51f42";
        private const string AUDIENCE = "c6bbbb645024";
        #endregion

        #region Métodos
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Configures the services.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            //Adiciona o contexto
            services.AddDbContext<EstoqueMangasContext>(options => options.UseMySql(new ConnectionStrings().MySQL()));

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

            services.ConfigurarToken(AUDIENCE, ISSUER);

            services.ConfigurarMvc();

            services.ConfigurarSwagger();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure the specified app and env.
        /// </summary>
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
        #endregion 
    }
}
