using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesisPadel.Migrations
{
    public partial class Ranking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Ranking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Club_ClubId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_ClubId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Ranking");
        }
    }
}
