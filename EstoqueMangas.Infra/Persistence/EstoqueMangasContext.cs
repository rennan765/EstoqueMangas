using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Infra.Persistence
{
    public class EstoqueMangasContext : DbContext
    {
        #region Propriedades
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion 

        #region Construtores
        public EstoqueMangasContext(DbContextOptions<EstoqueMangasContext> options) : base(options)
        {
            
        }
        #endregion

        #region Métodos
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("Server=localhost;User Id=estoque_mangas;Password=123qwe..;Database=EstoqueMangas");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.Mapeamento(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Mapeamento(ModelBuilder modelBuilder)
        {
            //Ignora classe de notificações
            modelBuilder.Ignore<Notification>();

            //Mapeamento da classe Usuario
            this.ConfiguraUsuario(modelBuilder);
        }

        private void ConfiguraUsuario(ModelBuilder modelBuilder)
        {
            //Mapeando campos simples
            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("TB_USUARIO");
                e.HasKey(u => u.Id)
                 .HasName("ID");
                e.Property(u => u.Senha)
                 .HasColumnName("SENHA")
                 .HasMaxLength(100)
                 .IsRequired();
                e.Property(u => u.Status)
                 .HasColumnName("STATUS")
                 .IsRequired();
            });

            //Mapeando campos com ValueObjets
            modelBuilder.Entity<Usuario>()
                        .OwnsOne<Email>(e => e.Email, ema =>
            {
                ema.Property(e => e.EnderecoEmail)
                   .HasColumnName("ENDERECO_EMAIL")
                   .HasMaxLength(150)
                   .IsRequired();
            })
                        .OwnsOne<Nome>(u => u.Nome, nom =>
            {
                nom.Property(n => n.PrimeiroNome)
                   .HasColumnName("PRIMEIRO_NOME")
                   .HasMaxLength(50)
                   .IsRequired();

                nom.Property(n => n.UltimoNome)
                   .HasColumnName("ULTIMO_NOME")
                   .HasMaxLength(50)
                   .IsRequired();
            })
                        .OwnsOne<Telefone>(t => t.TelefoneFixo, tel => 
            {
                tel.Property(t => t.Ddd)
                   .HasColumnName("DDD_TEL_FIXO")
                   .HasMaxLength(2);

                tel.Property(t => t.Numero)
                   .HasColumnName("NUMERO_TEL_FIXO")
                   .HasMaxLength(9);
            })
                        .OwnsOne<Telefone>(t => t.TelefoneCelular, tel =>
            {
                tel.Property(t => t.Ddd)
                   .HasColumnName("DDD_TEL_CELULAR")
                   .HasMaxLength(2);

                tel.Property(t => t.Numero)
                   .HasColumnName("NUMERO_TEL_CELULAR")
                   .HasMaxLength(9);
            });
        }
        #endregion 
    }
}
