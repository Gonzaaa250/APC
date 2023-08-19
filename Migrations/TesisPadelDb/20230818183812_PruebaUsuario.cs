using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class PruebaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Ranking_RankingId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Club_RankingId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "RankingId",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Ranking",
                newName: "Club");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ranking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClubId",
                table: "Usuario",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_UsuarioId",
                table: "Categoria",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Club_ClubId",
                table: "Usuario",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Club_ClubId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ClubId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_UsuarioId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "Club",
                table: "Ranking",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ranking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RankingId",
                table: "Club",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Club_RankingId",
                table: "Club",
                column: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Ranking_RankingId",
                table: "Club",
                column: "RankingId",
                principalTable: "Ranking",
                principalColumn: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
