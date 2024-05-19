using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizEntityId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizEntityId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuizEntityId",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuizEntityId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizEntityId",
                table: "Questions",
                column: "QuizEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizEntityId",
                table: "Questions",
                column: "QuizEntityId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}
