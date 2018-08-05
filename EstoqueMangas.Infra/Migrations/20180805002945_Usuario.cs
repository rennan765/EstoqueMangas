using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueMangas.Infra.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PRIMEIRO_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ULTIMO_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    ENDERECO_EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    DDD_TEL_FIXO = table.Column<int>(maxLength: 2, nullable: false),
                    NUMERO_TEL_FIXO = table.Column<string>(maxLength: 9, nullable: true),
                    DDD_TEL_CELULAR = table.Column<int>(maxLength: 2, nullable: false),
                    NUMERO_TEL_CELULAR = table.Column<string>(maxLength: 9, nullable: true),
                    SENHA = table.Column<string>(maxLength: 100, nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
