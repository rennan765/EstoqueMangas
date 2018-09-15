using EstoqueMangas.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstoqueMangas.Infra.Persistence.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstoqueMangasContext>
    {
        public EstoqueMangasContext CreateDbContext(string[] args)
        {
            string connectionString = "Server = localhost; User Id = root; Password = root; Database = EstoqueMangas";

            var builder = new DbContextOptionsBuilder<EstoqueMangasContext>();
            builder.UseMySql(connectionString);

            return new EstoqueMangasContext(builder.Options);
        }
    }
}
