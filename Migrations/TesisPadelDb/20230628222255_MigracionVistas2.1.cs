using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class MigracionVistas21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Ranking",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ranking_CategoriaId",
                table: "Ranking",
                newName: "IX_Ranking_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaRanking",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "int", nullable: false),
                    RankingsRankingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaRanking", x => new { x.CategoriasCategoriaId, x.RankingsRankingId });
                    table.ForeignKey(
                        name: "FK_CategoriaRanking_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaRanking_Ranking_RankingsRankingId",
                        column: x => x.RankingsRankingId,
                        principalTable: "Ranking",
                        principalColumn: "RankingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaRanking_RankingsRankingId",
                table: "CategoriaRanking",
                column: "RankingsRankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Usuarios_UsuarioId",
                table: "Ranking",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Usuarios_UsuarioId",
                table: "Ranking");

            migrationBuilder.DropTable(
                name: "CategoriaRanking");

            migrationBuilder.DropColumn(
                name: "Club",
                table: "Ranking");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Ranking",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ranking_UsuarioId",
                table: "Ranking",
                newName: "IX_Ranking_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId");
        }
    }
}
