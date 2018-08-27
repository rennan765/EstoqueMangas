using EstoqueMangas.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstoqueMangas.Infra.Persistence.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstoqueMangasContext>
    {
        public EstoqueMangasContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EstoqueMangasContext>();
            builder.UseMySql(ConnectionStrings.MySQL());

            return new EstoqueMangasContext(builder.Options);
        }
    }
}
