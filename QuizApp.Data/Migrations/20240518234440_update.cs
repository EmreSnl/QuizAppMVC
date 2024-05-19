using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Users_UserEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentResult_Users_UserEntityId",
                table: "StudentResult");

            migrationBuilder.DropIndex(
                name: "IX_StudentResult_UserEntityId",
                table: "StudentResult");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QuestionEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_UserEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "StudentResult");

            migrationBuilder.DropColumn(
                name: "QuestionEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "StudentAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "StudentResult",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionEntityId",
                table: "StudentAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "StudentAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_UserEntityId",
                table: "StudentResult",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionEntityId",
                table: "StudentAnswers",
                column: "QuestionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_UserEntityId",
                table: "StudentAnswers",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionEntityId",
                table: "StudentAnswers",
                column: "QuestionEntityId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Users_UserEntityId",
                table: "StudentAnswers",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResult_Users_UserEntityId",
                table: "StudentResult",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
