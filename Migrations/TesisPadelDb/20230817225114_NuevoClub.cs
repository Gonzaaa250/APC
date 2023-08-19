using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations.TesisPadelDb
{
    public partial class NuevoClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Club",
                table: "Ranking");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Ranking_RankingId",
                table: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Club_RankingId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "RankingId",
                table: "Club");

            migrationBuilder.AddColumn<string>(
                name: "Club",
                table: "Ranking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
