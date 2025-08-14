using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreRallyEventsAndNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Author", "Content", "ImageUrl", "IsFeatured", "PublishedOn", "SourceUrl", "Summary", "Title" },
                values: new object[,]
                {
                    { 3, "WRC Editorial", "Full preview: tyre choices, service plans and dust mitigation.", "/img/news/safari-preview.jpg", false, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/safari-preview", "Teams prepare for Naivasha’s punishing fesh-fesh.", "Safari preview: dust and strategy" },
                    { 4, "Press", "Shakedown analysis and quotes from leading crews.", "/img/news/finland-shakedown.jpg", true, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/finland-shakedown", "High-speed confidence ahead of the jumps.", "Finland shakedown times released" },
                    { 5, "WRC Editorial", "Route notes, stage profiles and car setup talk.", "/img/news/acropolis-route.jpg", false, new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/acropolis-route", "Heat and rocks set to test reliability.", "Acropolis returns with brutal stages" },
                    { 6, "Press", "Points permutations and power stage impact.", "/img/news/title-fight.jpg", true, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/title-fight", "Title race within single digits after summer rounds.", "Championship fight tightens" }
                });

            migrationBuilder.InsertData(
                table: "RallyEvents",
                columns: new[] { "Id", "Country", "Description", "EndDate", "ImageUrl", "Name", "StartDate", "Surface" },
                values: new object[,]
                {
                    { 4, "Kenya", "Iconic rough gravel endurance rally around Naivasha.", new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/rallies/safari-kenya-2025.jpg", "Safari Rally Kenya", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gravel" },
                    { 5, "Finland", "Fast jumps and crests around Jyväskylä.", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/rallies/rally-finland-2025.jpg", "Rally Finland", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gravel" },
                    { 6, "Greece", "Twisty, rocky mountain roads and heat management.", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/rallies/acropolis-2025.jpg", "Acropolis Rally Greece", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gravel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
