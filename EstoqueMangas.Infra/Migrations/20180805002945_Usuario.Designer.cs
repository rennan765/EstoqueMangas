﻿// <auto-generated />
using System;
using EstoqueMangas.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstoqueMangas.Infra.Migrations
{
    [DbContext(typeof(EstoqueMangasContext))]
    [Migration("20180805002945_Usuario")]
    partial class Usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EstoqueMangas.Core.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("ID");

                    b.ToTable("TB_USUARIO");
                });

            modelBuilder.Entity("EstoqueMangas.Core.Entities.Usuario", b =>
                {
                    b.OwnsOne("EstoqueMangas.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid?>("UsuarioId");

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasColumnName("ENDERECO_EMAIL")
                                .HasMaxLength(150);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Core.Entities.Usuario")
                                .WithOne("Email")
                                .HasForeignKey("EstoqueMangas.Core.ValueObjects.Email", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Core.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid?>("UsuarioId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PRIMEIRO_NOME")
                                .HasMaxLength(50);

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnName("ULTIMO_NOME")
                                .HasMaxLength(50);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Core.Entities.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("EstoqueMangas.Core.ValueObjects.Nome", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Core.ValueObjects.Telefone", "TelefoneCelular", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<int>("Ddd")
                                .HasColumnName("DDD_TEL_CELULAR")
                                .HasMaxLength(2);

                            b1.Property<string>("Numero")
                                .HasColumnName("NUMERO_TEL_CELULAR")
                                .HasMaxLength(9);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Core.Entities.Usuario")
                                .WithOne("TelefoneCelular")
                                .HasForeignKey("EstoqueMangas.Core.ValueObjects.Telefone", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Core.ValueObjects.Telefone", "TelefoneFixo", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<int>("Ddd")
                                .HasColumnName("DDD_TEL_FIXO")
                                .HasMaxLength(2);

                            b1.Property<string>("Numero")
                                .HasColumnName("NUMERO_TEL_FIXO")
                                .HasMaxLength(9);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Core.Entities.Usuario")
                                .WithOne("TelefoneFixo")
                                .HasForeignKey("EstoqueMangas.Core.ValueObjects.Telefone", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}