using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class Migracionotram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalidadId",
                table: "Usuarios",
                newName: "Localidad");

            migrationBuilder.RenameColumn(
                name: "EdadUsuario",
                table: "Usuarios",
                newName: "Edad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localidad",
                table: "Usuarios",
                newName: "LocalidadId");

            migrationBuilder.RenameColumn(
                name: "Edad",
                table: "Usuarios",
                newName: "EdadUsuario");
        }
    }
}
