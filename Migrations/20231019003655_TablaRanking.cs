using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations
{
    public partial class TablaRanking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Ranking_RankingId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RankingId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_CategoriaId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "RankingId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "UsuarioNombre",
                table: "Ranking");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_UsuarioId",
                table: "Ranking",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuario_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_UsuarioId",
                table: "Ranking");

            migrationBuilder.AddColumn<int>(
                name: "RankingId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Ranking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Ranking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNombre",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RankingId",
                table: "Usuario",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_CategoriaId",
                table: "Ranking",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Ranking_RankingId",
                table: "Usuario",
                column: "RankingId",
                principalTable: "Ranking",
                principalColumn: "RankingId");
        }
    }
}
