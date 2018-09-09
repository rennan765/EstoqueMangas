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
        public string MySQL()
        {
            return _configuration["ConnectionStrings:MySQL"];
        }

        public string SQLServer()
        {
            return _configuration["ConnectionStrings:SQLServer"];
        }
        #endregion 
    }
}
