using EstoqueMangas.Domain.Entities;
using EstoqueMangas.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapEditora : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            //Nome da tabela
            builder.ToTable("TB_EDITORA");

            //Campos simples
            builder.HasKey(e => e.Id)
                   .HasName("ID");

            builder.Property(e => e.Nome)
                   .HasColumnName("NOME")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasMany(e => e.Mangas)
                   .WithOne(m => m.Editora);

            //ValueObjects
            builder.Ignore(e => e.Endereco);

            builder.OwnsOne(e => e.Endereco, endereco => 
            {
                endereco.Property(e => e.Logradouro)
                        .HasColumnName("LOGRADOURO")
                        .HasMaxLength(100)
                        .IsRequired();

                endereco.Property(e => e.Numero)
                        .HasColumnName("NUMERO")
                        .HasMaxLength(10)
                        .HasDefaultValue("");

                endereco.Property(e => e.Complemento)
                        .HasColumnName("COMPLEMENTO")
                        .HasMaxLength(50)
                        .HasDefaultValue("");

                endereco.Property(e => e.Bairro)
                        .HasColumnName("BAIRRO")
                        .HasMaxLength(50)
                        .IsRequired();

                endereco.Property(e => e.Cidade)
                        .HasColumnName("CIDADE")
                        .HasMaxLength(50)
                        .IsRequired();

                endereco.Property(e => e.Estado)
                        .HasColumnName("ESTADO")
                        .HasMaxLength(20)
                        .IsRequired();

                endereco.Property(e => e.Cep)
                        .HasColumnName("CEP")
                        .HasMaxLength(8)
                        .IsRequired();
            })
                .OwnsOne(t => t.Telefone, tel =>
            {
                tel.Property(t => t.Ddd)
                   .HasColumnName("DDD_TELEFONE")
                   .HasMaxLength(2);

                tel.Property(t => t.Numero)
                   .HasColumnName("NUMERO_TELEFONE")
                   .HasMaxLength(9);
            });
        }
    }
}
