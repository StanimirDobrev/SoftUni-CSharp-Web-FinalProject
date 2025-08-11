using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    SourceUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4390e75-19a2-40dc-892c-aaf9a6767f57", "AQAAAAIAAYagAAAAEOjw0JIitlquqTJy/+yZPQxRsK6qvAFU7aSA0EDy8G78oBTMRRJ2BNXcee4mvxQ2UA==", "08c5ee2a-d0cb-4c86-8b8f-9bd6c78a5294" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Author", "Content", "ImageUrl", "IsFeatured", "PublishedOn", "SourceUrl", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "WRC Editorial", "Full article content here...", "/img/news/monte.jpg", true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/monte", "Iconic season opener returns with night stages and tight mountain passes.", "Rallye Monte-Carlo: Opening Round Confirmed" },
                    { 2, "Press", "Full article content here...", "/img/news/fight.jpg", true, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Point gap narrows after dramatic Power Stage.", "Evans vs Neuville: Early Title Fight" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4fb734c-3eaf-4bc5-a183-dd14573b7961", "AQAAAAIAAYagAAAAEH0RF2GjBRkufVuMi10RkMZS3TJ1oe2YQ3/s/rEf0J9x/+P/71qNZCMdUk9tgFNKLQ==", "840138d7-cb0a-4cec-a520-780445cb6997" });
        }
    }
}
