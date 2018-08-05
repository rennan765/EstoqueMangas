//using System;
//using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

namespace EstoqueMangas.Infra.Persistence.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstoqueMangasContext>
    {
        public EstoqueMangasContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json")
                //.Build();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<EstoqueMangasContext>();
            builder.UseMySql("Server=localhost;User Id=root;Password=root;Database=EstoqueMangas");
            return new EstoqueMangasContext(builder.Options);
        }
    }
}
