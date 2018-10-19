using EstoqueMangas.CrossCutting.Connection;
using EstoqueMangas.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.CrossCutting.IoC.Resolvers
{
    public static class ContextResolver
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services)
        {
            //Adiciona o contexto
            services.AddDbContext<EstoqueMangasContext>(options => options.UseMySql(new ConnectionStrings().MySql()));

            return services;
        }
    }
}
