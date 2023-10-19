using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations
{
    public partial class Ranking_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioNombre",
                table: "Ranking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioNombre",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
