using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_flicker_project_server.Migrations
{
    public partial class MigracaoScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Cars_CarId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CarId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Scores",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CarModelId",
                table: "Scores",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Cars_CarModelId",
                table: "Scores",
                column: "CarModelId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Cars_CarModelId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CarModelId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Scores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CarId",
                table: "Scores",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Cars_CarId",
                table: "Scores",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
