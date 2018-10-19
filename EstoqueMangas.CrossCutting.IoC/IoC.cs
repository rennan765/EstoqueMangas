using EstoqueMangas.CrossCutting.IoC.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.CrossCutting.IoC
{
    public static class IoC
    {


        #region Métodos
        public static IServiceCollection ResolveApi(this IServiceCollection services)
        {
            services.ConfigureContext()
                    .ConfigureContextAccessor()
                    .ConfigureServices()
                    .ConfigureRepositories()
                    .ConfigureToken()
                    .ConfigureMvc()
                    .ConfigureSwagger();

            return services;
        }
        #endregion 
    }
}
