using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class tablaR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "Club",
                table: "Ranking");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ranking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Ranking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Ranking");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ranking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
