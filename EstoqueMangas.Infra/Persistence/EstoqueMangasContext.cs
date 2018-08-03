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

        public EstoqueMangasContext(DbContextOptions<EstoqueMangasContext> options) : base(options)
        {
            
        }
        #endregion

        #region Métodos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=estoque_mangas;Password=123qwe..;Database=EstoqueMangas");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfiguraUsuario(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfiguraUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(e => 
            {
                e.ToTable("TB_USUARIO");
                e.HasKey(u => u.Id)
                    .HasName("ID");
                e.Property(u => u.Nome.PrimeiroNome)
                    .HasColumnName("PRIMEIRO_NOME")
                    .HasColumnType("varchar").HasMaxLength(50)
                    .IsRequired();
                e.Property(u => u.Nome.UltimoNome)
                    .HasColumnName("ULTIMO_NOME")
                    .HasColumnType("varchar").HasMaxLength(50)
                    .IsRequired();
                e.Property(u => u.Email.EnderecoEmail)
                    .HasColumnName("ENDERECO_EMAIL")
                    .HasColumnType("varchar").HasMaxLength(150)
                    .IsRequired();
                e.Property(u => u.TelefoneFixo.Ddd)
                 .HasColumnName("DDD_TEL_FIXO")
                    .HasColumnType("varchar").HasMaxLength(2);
                e.Property(u => u.TelefoneFixo.Numero)
                    .HasColumnName("NUMERO_TEL_FIXO")
                    .HasColumnType("varchar").HasMaxLength(9);
                e.Property(u => u.TelefoneCelular.Ddd)
                    .HasColumnName("DDD_TEL_CELULAR")
                    .HasColumnType("varchar")
                    .HasMaxLength(2);
                e.Property(u => u.TelefoneCelular.Numero)
                    .HasColumnName("NUMERO_TEL_CELULAR")
                    .HasColumnType("varchar").HasMaxLength(9);
                e.Property(u => u.Senha)
                    .HasColumnName("SENHA")
                    .HasColumnType("varchar").HasMaxLength(100)
                    .IsRequired();
                e.Property(u => u.Status)
                    .HasColumnName("STATUS").HasColumnType("int")
                    .IsRequired();
            });
        }
        #endregion 
    }
}
