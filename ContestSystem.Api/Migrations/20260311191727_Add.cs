using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContestSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$QzPSQb09h3uGAQP5n20sHuJgtPJmlBvHdn5DgfzbvGMJ1y6I0XKGi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$06OhodCXstXd8Gs.dhUusuPfbe/E1y417u7rMSP5ozN2tsXkbFJ1a");
        }
    }
}
