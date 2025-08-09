using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7699db7d-964f-4782-8209-d76562e0fece", 0, "de67f6f5-5020-4fe7-8251-b4c7d8aed525", "admin@horizons.com", true, false, null, "ADMIN@HORIZONS.COM", "ADMIN@HORIZONS.COM", "AQAAAAIAAYagAAAAEPJVHtElkNffGjaUzypESBFBYdiWwAvZyUC6DMxsu3LG+6meTZ8MgdpAfedmPp+KXQ==", null, false, "e606382c-3d84-4622-8196-e2062677ff29", false, "admin@horizons.com" });

            migrationBuilder.InsertData(
                table: "RallyEvents",
                columns: new[] { "Id", "Country", "Description", "EndDate", "ImageUrl", "Name", "StartDate", "Surface" },
                values: new object[,]
                {
                    { 1, "Monaco / France", "Legendary winter tarmac rally.", new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.wrc.com/assets/img/events/montecarlo.jpg", "Rallye Monte-Carlo", new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarmac" },
                    { 2, "Sweden", "Fast snow stages with snowbanks.", new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.wrc.com/assets/img/events/sweden.jpg", "Rally Sweden", new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snow" },
                    { 3, "Croatia", "Technical tarmac with tricky cuts.", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.wrc.com/assets/img/events/croatia.jpg", "Croatia Rally", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarmac" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LogoUrl", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 1, "https://www.wrc.com/assets/img/teams/toyota-logo.png", "Toyota", "Toyota Gazoo Racing" },
                    { 2, "https://www.wrc.com/assets/img/teams/hyundai-logo.png", "Hyundai", "Hyundai Shell Mobis" },
                    { 3, "https://www.wrc.com/assets/img/teams/ford-logo.png", "Ford", "M-Sport Ford" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "Nationality", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalle", "https://www.wrc.com/assets/img/drivers/kalle-rovanpera.png", "Rovanperä", "Finland", 1 },
                    { 2, new DateTime(1988, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elfyn", "https://www.wrc.com/assets/img/drivers/elfyn-evans.png", "Evans", "Wales", 1 },
                    { 3, new DateTime(1988, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thierry", "https://www.wrc.com/assets/img/drivers/thierry-neuville.png", "Neuville", "Belgium", 2 },
                    { 4, new DateTime(1987, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ott", "https://www.wrc.com/assets/img/drivers/ott-tanak.png", "Tänak", "Estonia", 2 },
                    { 5, new DateTime(1995, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrien", "https://www.wrc.com/assets/img/drivers/adrien-fourmaux.png", "Fourmaux", "France", 3 },
                    { 6, new DateTime(1998, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grégoire", "https://www.wrc.com/assets/img/drivers/gregoire-munster.png", "Munster", "Luxembourg", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
