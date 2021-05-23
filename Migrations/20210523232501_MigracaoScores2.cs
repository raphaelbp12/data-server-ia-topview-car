using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_flicker_project_server.Migrations
{
    public partial class MigracaoScores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Cars_CarModelId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ParentsIds",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarModelId",
                table: "Scores",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_CarModelId",
                table: "Scores",
                newName: "IX_Scores_CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Cars_CarId",
                table: "Scores",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Cars_CarId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Scores",
                newName: "CarModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_CarId",
                table: "Scores",
                newName: "IX_Scores_CarModelId");

            migrationBuilder.AddColumn<List<int>>(
                name: "ParentsIds",
                table: "Cars",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "ScoreId",
                table: "Cars",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Cars_CarModelId",
                table: "Scores",
                column: "CarModelId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
