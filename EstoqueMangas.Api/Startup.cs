using EstoqueMangas.Api.Extensions;
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
using System;

namespace EstoqueMangas.Api
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        #region Atributos
        private const string Issuer = "c1f51f42";
        private const string Audience = "c6bbbb645024";
        #endregion

        #region Métodos
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Configures the services.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigurarContexto()
                    .ConfigurarAcessorDeContexto()
                    .ConfigurarServicos()
                    .ConfigurarRepositorios()
                    .ConfigurarToken(Audience, Issuer)
                    .ConfigurarMvc()
                    .ConfigurarSwagger();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configure the specified app and env.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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
                c.SwaggerEndpoint($"{(string.IsNullOrEmpty(c.RoutePrefix) ? "." : "..")}/swagger/v1/swagger.json", "EstoqueMangas - V1");
            });

            //Inicializa o banco de dados e migra pra versão mais recente.
            serviceProvider.GetService<IUnitOfWork>().Incializar();
        }
        #endregion 
    }
}
