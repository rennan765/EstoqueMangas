using System;
using EstoqueMangas.Domain.Entities.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapAutorManga : IEntityTypeConfiguration<AutorManga>
    {
        public void Configure(EntityTypeBuilder<AutorManga> builder)
        {
            //Nome da tabela
            builder.ToTable("JOIN_AUTOR_MANGA");

            //Campos
            builder.HasKey(am => new { am.AutorId, am.MangaId });

            builder.HasOne(am => am.Autor)
                   .WithMany(a => a.Mangas)
                   .HasForeignKey(am => am.AutorId);

            builder.HasOne(am => am.Manga)
                   .WithMany(m => m.Autores)
                   .HasForeignKey(am => am.MangaId);

            builder.Ignore(am => am.Id);
        }
    }
}
