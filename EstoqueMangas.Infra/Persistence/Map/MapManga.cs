using EstoqueMangas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapManga : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            //Nome da tabela
            builder.ToTable("TB_MANGA");

            //Campos simples
            builder.HasKey(u => u.Id)
             .HasName("ID");

            builder.Property(m => m.Titulo)
                   .HasColumnName("TITULO")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(u => u.AnoLancamento)
             .HasColumnName("ANO_LANCAMENTO")
             .HasMaxLength(4)
             .IsRequired();

            builder.HasOne(m => m.Editora)
                   .WithMany(e => e.Mangas)
                   .HasForeignKey(m => m.EditoraId)
                   .IsRequired();

            builder.Property(e => e.EdicaoManga)
                   .HasColumnName("EDICAO_MANGA");

            builder.HasMany(m => m.Edicoes)
                   .WithOne(e => e.Manga)
                   .IsRequired();
        }
    }
}
