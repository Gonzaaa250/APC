using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class Nuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaRanking");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankingId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CategoriaId",
                table: "Usuarios",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_RankingId",
                table: "Categoria",
                column: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Ranking_RankingId",
                table: "Categoria",
                column: "RankingId",
                principalTable: "Ranking",
                principalColumn: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Categoria_CategoriaId",
                table: "Usuarios",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Ranking_RankingId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Categoria_CategoriaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CategoriaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_RankingId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RankingId",
                table: "Categoria");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }
    }
}
