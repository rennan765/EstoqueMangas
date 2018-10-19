using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueMangas.Infra.Migrations
{
    public partial class EdicaoManga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EDICAO_MANGA",
                table: "TB_EDICAO");

            migrationBuilder.AddColumn<string>(
                name: "EDICAO_MANGA",
                table: "TB_MANGA",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EDICAO_MANGA",
                table: "TB_MANGA");

            migrationBuilder.AddColumn<string>(
                name: "EDICAO_MANGA",
                table: "TB_EDICAO",
                nullable: false,
                defaultValue: "");
        }
    }
}
