using Microsoft.Extensions.Configuration;
using System.IO;

namespace EstoqueMangas.CrossCutting.Connection
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
