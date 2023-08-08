using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class EliminarLocalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropIndex(
                name: "IX_Club_LocalidadId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Club");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Club",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Club");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    LocalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.LocalidadId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_LocalidadId",
                table: "Club",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
