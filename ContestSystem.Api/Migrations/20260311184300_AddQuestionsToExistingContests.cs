using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContestSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionsToExistingContests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Submissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Contests",
                columns: new[] { "Id", "AccessLevel", "Description", "EndTime", "Name", "Prize", "StartTime" },
                values: new object[,]
                {
                    { 1, "Normal", "General Knowledge", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic C# Quiz", "Bronze Medal", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Normal", "Database Quiz", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Logic", "Silver Medal", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "VIP", "Pro Level", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP Algorithms", "Gold Trophy", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "VIP", "Architecture", new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "System Design", "Platinum Trophy", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "admin@gmail.com", "$2a$11$06OhodCXstXd8Gs.dhUusuPfbe/E1y417u7rMSP5ozN2tsXkbFJ1a", "3", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ContestId", "Points", "Text", "Type" },
                values: new object[,]
                {
                    { 1, 1, 10, "What is the base class for all types in .NET?", "Single" },
                    { 2, 2, 20, "Which SQL clause is used to filter groups?", "Single" },
                    { 3, 3, 50, "Which algorithms are O(n log n)?", "Multi" },
                    { 4, 4, 100, "What is the primary benefit of microservices?", "Single" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "System.Object" },
                    { 2, false, 1, "System.Base" },
                    { 3, true, 2, "HAVING" },
                    { 4, false, 2, "WHERE" },
                    { 5, true, 3, "Merge Sort" },
                    { 6, true, 3, "Quick Sort" },
                    { 7, false, 3, "Bubble Sort" },
                    { 8, true, 4, "Scalability" },
                    { 9, false, 4, "Monolithic simplicity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ContestId",
                table: "Submissions",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Contests_ContestId",
                table: "Submissions",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Contests_ContestId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_ContestId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Submissions");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
