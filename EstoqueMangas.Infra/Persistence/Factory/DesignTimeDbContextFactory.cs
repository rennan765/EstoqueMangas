﻿using EstoqueMangas.CrossCutting.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstoqueMangas.Infra.Persistence.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstoqueMangasContext>
    {
        public EstoqueMangasContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EstoqueMangasContext>();
            builder.UseMySql(new ConnectionStrings().MySql());

            return new EstoqueMangasContext(builder.Options);
        }
    }
}
