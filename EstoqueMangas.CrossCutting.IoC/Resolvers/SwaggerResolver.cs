using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;

namespace EstoqueMangas.CrossCutting.IoC.Resolvers
{
    public static class SwaggerResolver
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
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
    }
}
