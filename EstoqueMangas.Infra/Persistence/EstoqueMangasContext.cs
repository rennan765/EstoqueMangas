using System;
using EstoqueMangas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstoqueMangas.Infra.Persistence
{
    public class EstoqueMangasContext : DbContext
    {
        #region Propriedades
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion 

        #region Construtores
        public EstoqueMangasContext() 
        {

        }
        #endregion

        #region Métodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion 
    }
}
