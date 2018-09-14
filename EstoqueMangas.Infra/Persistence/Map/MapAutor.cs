using EstoqueMangas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapAutor : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            //Nome da tabela
            builder.ToTable("TB_AUTOR");

            //Campos simples
            builder.HasKey(a => a.Id)
                   .HasName("ID");

            //ValueObjects
            builder.Ignore(a => a.NomeAutor);

            builder.OwnsOne(n => n.NomeAutor, nom =>
            {
                nom.Property(n => n.PrimeiroNome)
                  .HasColumnName("PRIMEIRO_NOME")
                  .HasMaxLength(50)
                  .IsRequired();

                nom.Property(n => n.UltimoNome)
                   .HasColumnName("ULTIMO_NOME")
                   .HasMaxLength(50)
                   .IsRequired();
            });
        }
    }
}
