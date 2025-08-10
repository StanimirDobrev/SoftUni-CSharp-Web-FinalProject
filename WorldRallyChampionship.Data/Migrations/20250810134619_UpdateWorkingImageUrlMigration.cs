using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkingImageUrlMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/drivers/kalle-rovampera.jpg");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/img/drivers/elfyn-evans.jpg");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/img/drivers/thierry-neuville.jpg");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/img/drivers/ott-tanak.jpg");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/img/drivers/adrien-fourmaux.jpg");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/img/drivers/gregoire-munster.jpg");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4fb734c-3eaf-4bc5-a183-dd14573b7961", "AQAAAAIAAYagAAAAEH0RF2GjBRkufVuMi10RkMZS3TJ1oe2YQ3/s/rEf0J9x/+P/71qNZCMdUk9tgFNKLQ==", "840138d7-cb0a-4cec-a520-780445cb6997" });

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/rallies/rallye-monte-carlo-2025.jpg");

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/img/rallies/wrc-rally-sweden-2025.jpg");

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/img/rallies/croatia-rally-2025.jpg");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "/img/teams/toyota.jpg");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "/img/teams/hyundai.jpg");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "/img/teams/m-sport ford.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/kalle-rovanpera.png");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/elfyn-evans.png");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/thierry-neuville.png");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/ott-tanak.png");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/adrien-fourmaux.png");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/drivers/gregoire-munster.png");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de67f6f5-5020-4fe7-8251-b4c7d8aed525", "AQAAAAIAAYagAAAAEPJVHtElkNffGjaUzypESBFBYdiWwAvZyUC6DMxsu3LG+6meTZ8MgdpAfedmPp+KXQ==", "e606382c-3d84-4622-8196-e2062677ff29" });

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/events/montecarlo.jpg");

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/events/sweden.jpg");

            migrationBuilder.UpdateData(
                table: "RallyEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.wrc.com/assets/img/events/croatia.jpg");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "https://www.wrc.com/assets/img/teams/toyota-logo.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "https://www.wrc.com/assets/img/teams/hyundai-logo.png");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "https://www.wrc.com/assets/img/teams/ford-logo.png");
        }
    }
}
