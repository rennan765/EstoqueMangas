using EstoqueMangas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapEdicao : IEntityTypeConfiguration<Edicao>
    {
        public void Configure(EntityTypeBuilder<Edicao> builder)
        {
            //Nome da tabela
            builder.ToTable("TB_EDICAO");

            //Campos 
            builder.HasKey(e => e.Id)
                   .HasName("ID");

            builder.Property(e => e.Numero)
                   .HasColumnName("NUMERO")
                   .IsRequired();

            builder.Property(e => e.EdicaoManga)
                   .HasColumnName("EDICAO_MANGA")
                   .HasDefaultValue("")
                   .IsRequired();

            builder.HasOne(e => e.Manga)
                   .WithMany()
                   .HasForeignKey(e => e.MangaId)
                   .IsRequired();
        }
    }
}
