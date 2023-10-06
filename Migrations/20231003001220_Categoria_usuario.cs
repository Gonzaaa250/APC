using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations
{
    public partial class Categoria_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Ranking");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Ranking",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking",
                newName: "IX_Ranking_CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankingId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Puntos",
                table: "Ranking",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CategoriaId",
                table: "Usuario",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RankingId",
                table: "Usuario",
                column: "RankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Categoria_CategoriaId",
                table: "Usuario",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Ranking_RankingId",
                table: "Usuario",
                column: "RankingId",
                principalTable: "Ranking",
                principalColumn: "RankingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Categoria_CategoriaId",
                table: "Ranking");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Categoria_CategoriaId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Ranking_RankingId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CategoriaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RankingId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RankingId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Ranking",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Ranking_CategoriaId",
                table: "Ranking",
                newName: "IX_Ranking_ClubId");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Puntos",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
