using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class numero2000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Categoria_CategoriaId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaId",
                table: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Localidad_ProvinciaId",
                table: "Localidad");

            migrationBuilder.DropIndex(
                name: "IX_Club_CategoriaId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Club");

            migrationBuilder.AlterColumn<string>(
                name: "LNombre",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Club",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadId",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Localidad");

            migrationBuilder.AlterColumn<string>(
                name: "LNombre",
                table: "Localidad",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Localidad",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Club",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadId",
                table: "Club",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Club",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Club",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProvincia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciaId",
                table: "Localidad",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_CategoriaId",
                table: "Club",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Categoria_CategoriaId",
                table: "Club",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Localidad_LocalidadId",
                table: "Club",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaId",
                table: "Localidad",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "ProvinciaId");
        }
    }
}
