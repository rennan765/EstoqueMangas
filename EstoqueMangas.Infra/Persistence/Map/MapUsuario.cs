﻿using EstoqueMangas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueMangas.Infra.Persistence.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Nome da tabela
            builder.ToTable("TB_USUARIO");

            //Campos simples
            builder.HasKey(u => u.Id)
             .HasName("ID");
            
            builder.Property(u => u.Senha)
             .HasColumnName("SENHA")
             .HasMaxLength(100)
             .IsRequired();
            
            builder.Property(u => u.Status)
             .HasColumnName("STATUS")
             .IsRequired();

            //ValueObjects
            builder.Ignore(u => u.Nome)
                   .Ignore(u => u.Email)
                   .Ignore(u => u.TelefoneFixo)
                   .Ignore(u => u.TelefoneCelular);

            builder.OwnsOne(e => e.Email, ema =>
            {
                ema.Property(e => e.EnderecoEmail)
                .HasColumnName("ENDERECO_EMAIL")
                .HasMaxLength(150)
                .IsRequired();
            })
                .OwnsOne(u => u.Nome, nom =>
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
                .OwnsOne(t => t.TelefoneFixo, tel =>
            {
                tel.Property(t => t.Ddd)
                   .HasColumnName("DDD_TEL_FIXO")
                   .HasMaxLength(2);

                tel.Property(t => t.Numero)
                   .HasColumnName("NUMERO_TEL_FIXO")
                   .HasMaxLength(9);
            })
                .OwnsOne(t => t.TelefoneCelular, tel =>
            {
                tel.Property(t => t.Ddd)
                   .HasColumnName("DDD_TEL_CELULAR")
                   .HasMaxLength(2);

                tel.Property(t => t.Numero)
                   .HasColumnName("NUMERO_TEL_CELULAR")
                   .HasMaxLength(9);
            });
        }
    }
}
