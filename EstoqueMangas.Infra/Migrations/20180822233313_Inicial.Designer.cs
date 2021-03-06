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
    [Migration("20180822233313_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Autor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id")
                        .HasName("ID");

                    b.ToTable("TB_AUTOR");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Edicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EdicaoManga")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EDICAO_MANGA")
                        .HasDefaultValue("");

                    b.Property<Guid>("MangaId");

                    b.Property<Guid?>("MangaId1");

                    b.Property<int>("Numero")
                        .HasColumnName("NUMERO");

                    b.HasKey("Id")
                        .HasName("ID");

                    b.HasIndex("MangaId");

                    b.HasIndex("MangaId1");

                    b.ToTable("TB_EDICAO");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Editora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(200);

                    b.HasKey("Id")
                        .HasName("ID");

                    b.ToTable("TB_EDITORA");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Join.AutorManga", b =>
                {
                    b.Property<Guid>("AutorId");

                    b.Property<Guid>("MangaId");

                    b.HasKey("AutorId", "MangaId");

                    b.HasIndex("MangaId");

                    b.ToTable("JOIN_AUTOR_MANGA");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Manga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoLancamento")
                        .HasColumnName("ANO_LANCAMENTO")
                        .HasMaxLength(4);

                    b.Property<Guid>("EditoraId");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasMaxLength(500);

                    b.HasKey("Id")
                        .HasName("ID");

                    b.HasIndex("EditoraId");

                    b.ToTable("TB_MANGA");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Usuario", b =>
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

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Autor", b =>
                {
                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Nome", "NomeAutor", b1 =>
                        {
                            b1.Property<Guid>("AutorId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PRIMEIRO_NOME")
                                .HasMaxLength(50);

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnName("ULTIMO_NOME")
                                .HasMaxLength(50);

                            b1.ToTable("TB_AUTOR");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Autor")
                                .WithOne("NomeAutor")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Nome", "AutorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Edicao", b =>
                {
                    b.HasOne("EstoqueMangas.Domain.Entities.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstoqueMangas.Domain.Entities.Manga")
                        .WithMany("Edicoes")
                        .HasForeignKey("MangaId1");
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Editora", b =>
                {
                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("EditoraId");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnName("BAIRRO")
                                .HasMaxLength(50);

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnName("CEP")
                                .HasMaxLength(8);

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("CIDADE")
                                .HasMaxLength(50);

                            b1.Property<string>("Complemento")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("COMPLEMENTO")
                                .HasMaxLength(50)
                                .HasDefaultValue("");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnName("ESTADO")
                                .HasMaxLength(20);

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("LOGRADOURO")
                                .HasMaxLength(100);

                            b1.Property<string>("Numero")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("NUMERO")
                                .HasMaxLength(10)
                                .HasDefaultValue("");

                            b1.ToTable("TB_EDITORA");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Editora")
                                .WithOne("Endereco")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Endereco", "EditoraId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("EditoraId");

                            b1.Property<string>("Ddd")
                                .HasColumnName("DDD_TELEFONE")
                                .HasMaxLength(2);

                            b1.Property<string>("Numero")
                                .HasColumnName("NUMERO_TELEFONE")
                                .HasMaxLength(9);

                            b1.ToTable("TB_EDITORA");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Editora")
                                .WithOne("Telefone")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Telefone", "EditoraId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Join.AutorManga", b =>
                {
                    b.HasOne("EstoqueMangas.Domain.Entities.Autor", "Autor")
                        .WithMany("Mangas")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstoqueMangas.Domain.Entities.Manga", "Manga")
                        .WithMany("Autores")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Manga", b =>
                {
                    b.HasOne("EstoqueMangas.Domain.Entities.Editora", "Editora")
                        .WithMany("Mangas")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstoqueMangas.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasColumnName("ENDERECO_EMAIL")
                                .HasMaxLength(150);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Usuario")
                                .WithOne("Email")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Email", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PRIMEIRO_NOME")
                                .HasMaxLength(50);

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnName("ULTIMO_NOME")
                                .HasMaxLength(50);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Nome", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Telefone", "TelefoneCelular", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Ddd")
                                .HasColumnName("DDD_TEL_CELULAR")
                                .HasMaxLength(2);

                            b1.Property<string>("Numero")
                                .HasColumnName("NUMERO_TEL_CELULAR")
                                .HasMaxLength(9);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Usuario")
                                .WithOne("TelefoneCelular")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Telefone", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EstoqueMangas.Domain.ValueObjects.Telefone", "TelefoneFixo", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Ddd")
                                .HasColumnName("DDD_TEL_FIXO")
                                .HasMaxLength(2);

                            b1.Property<string>("Numero")
                                .HasColumnName("NUMERO_TEL_FIXO")
                                .HasMaxLength(9);

                            b1.ToTable("TB_USUARIO");

                            b1.HasOne("EstoqueMangas.Domain.Entities.Usuario")
                                .WithOne("TelefoneFixo")
                                .HasForeignKey("EstoqueMangas.Domain.ValueObjects.Telefone", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
