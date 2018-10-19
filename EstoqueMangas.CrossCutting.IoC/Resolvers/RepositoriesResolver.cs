using EstoqueMangas.Domain.Interfaces.Repositores;
using EstoqueMangas.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.CrossCutting.IoC.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>()
                .AddTransient<IRepositoryAutor, RepositoryAutor>()
                .AddTransient<IRepositoryManga, RepositoryManga>()
                .AddTransient<IRepositoryAutorManga, RepositoryAutorManga>()
                .AddTransient<IRepositoryEdicao, RepositoryEdicao>()
                .AddTransient<IRepositoryEditora, RepositoryEditora>();

            return services;
        }
    }
}
