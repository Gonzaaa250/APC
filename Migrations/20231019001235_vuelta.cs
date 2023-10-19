using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations
{
    public partial class vuelta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioNombre",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioNombre",
                table: "Ranking");
        }
    }
}
