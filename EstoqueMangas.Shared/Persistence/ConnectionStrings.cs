using System.IO;
using Microsoft.Extensions.Configuration;

namespace EstoqueMangas.Shared.Persistence
{
    public class ConnectionStrings
    {
        #region Atributos
        private readonly IConfiguration _configuration;
        #endregion

        #region Construtores
        public ConnectionStrings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }
        #endregion 

        #region Métodos
        public string MySql()
        {
            return _configuration["ConnectionStrings:MySql"];
        }

        public string SqlServer()
        {
            return _configuration["ConnectionStrings:SqlServer"];
        }
        #endregion 
    }
}
