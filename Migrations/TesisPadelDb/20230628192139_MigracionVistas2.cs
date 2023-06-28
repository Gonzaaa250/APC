using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class MigracionVistas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioBirhtDate",
                table: "Usuarios",
                newName: "EdadUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EdadUsuario",
                table: "Usuarios",
                newName: "UsuarioBirhtDate");
        }
    }
}
