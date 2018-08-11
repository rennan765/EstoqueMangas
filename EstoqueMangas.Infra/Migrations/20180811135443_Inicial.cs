using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueMangas.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_AUTOR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PRIMEIRO_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ULTIMO_NOME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_EDITORA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    LOGRADOURO = table.Column<string>(maxLength: 100, nullable: false),
                    NUMERO = table.Column<string>(maxLength: 10, nullable: true, defaultValue: ""),
                    COMPLEMENTO = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    BAIRRO = table.Column<string>(maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(maxLength: 20, nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false),
                    DDD_TELEFONE = table.Column<string>(maxLength: 2, nullable: true),
                    NUMERO_TELEFONE = table.Column<string>(maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PRIMEIRO_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ULTIMO_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ENDERECO_EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    DDD_TEL_FIXO = table.Column<string>(maxLength: 2, nullable: true),
                    NUMERO_TEL_FIXO = table.Column<string>(maxLength: 9, nullable: true),
                    DDD_TEL_CELULAR = table.Column<string>(maxLength: 2, nullable: true),
                    NUMERO_TEL_CELULAR = table.Column<string>(maxLength: 9, nullable: true),
                    SENHA = table.Column<string>(maxLength: 100, nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MANGA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    ANO_LANCAMENTO = table.Column<int>(maxLength: 4, nullable: false),
                    EditoraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_MANGA_TB_EDITORA_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "TB_EDITORA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JOIN_AUTOR_MANGA",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(nullable: false),
                    AutorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOIN_AUTOR_MANGA", x => new { x.AutorId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_JOIN_AUTOR_MANGA_TB_AUTOR_AutorId",
                        column: x => x.AutorId,
                        principalTable: "TB_AUTOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JOIN_AUTOR_MANGA_TB_MANGA_MangaId",
                        column: x => x.MangaId,
                        principalTable: "TB_MANGA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EDICAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MangaId = table.Column<Guid>(nullable: false),
                    EDICAO_MANGA = table.Column<string>(nullable: false, defaultValue: ""),
                    NUMERO = table.Column<int>(nullable: false),
                    MangaId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EDICAO_TB_MANGA_MangaId",
                        column: x => x.MangaId,
                        principalTable: "TB_MANGA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_EDICAO_TB_MANGA_MangaId1",
                        column: x => x.MangaId1,
                        principalTable: "TB_MANGA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JOIN_AUTOR_MANGA_MangaId",
                table: "JOIN_AUTOR_MANGA",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EDICAO_MangaId",
                table: "TB_EDICAO",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EDICAO_MangaId1",
                table: "TB_EDICAO",
                column: "MangaId1");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MANGA_EditoraId",
                table: "TB_MANGA",
                column: "EditoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JOIN_AUTOR_MANGA");

            migrationBuilder.DropTable(
                name: "TB_EDICAO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_AUTOR");

            migrationBuilder.DropTable(
                name: "TB_MANGA");

            migrationBuilder.DropTable(
                name: "TB_EDITORA");
        }
    }
}
