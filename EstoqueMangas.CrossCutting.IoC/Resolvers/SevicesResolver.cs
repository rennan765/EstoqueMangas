using EstoqueMangas.Domain.Interfaces.Services;
using EstoqueMangas.Domain.Interfaces.Transactions;
using EstoqueMangas.Domain.Services;
using EstoqueMangas.Infra.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.CrossCutting.IoC.Resolvers
{
    public static class SevicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IServiceUsuario, ServiceUsuario>()
                .AddTransient<IServiceEditora, ServiceEditora>()
                .AddTransient<IServiceAutor, ServiceAutor>();

            return services;
        }
    }
}
