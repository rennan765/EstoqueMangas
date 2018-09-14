using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.Entities.Join;
using EstoqueMangas.Infra.Persistence.Map;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace EstoqueMangas.Infra.Persistence
{
    public class EstoqueMangasContext : DbContext
    {
        #region Propriedades
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Manga> Mangas { get; set;} 
        public DbSet<Autor> Autores { get; set;} 
        public DbSet<AutorManga> AutoresMangas { get; set;} 
        public DbSet<Editora> Editoras { get; set;} 
        public DbSet<Edicao> Edicao { get; set;} 
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mapeamento(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void Mapeamento(ModelBuilder modelBuilder)
        {
            //Ignora classe de notificações
            modelBuilder.Ignore<Notification>();

            //Mapeamento das classes
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapAutor());
            modelBuilder.ApplyConfiguration(new MapManga());
            modelBuilder.ApplyConfiguration(new MapAutorManga());
            modelBuilder.ApplyConfiguration(new MapEdicao());
            modelBuilder.ApplyConfiguration(new MapEditora());
        }
        #endregion 
    }
}
