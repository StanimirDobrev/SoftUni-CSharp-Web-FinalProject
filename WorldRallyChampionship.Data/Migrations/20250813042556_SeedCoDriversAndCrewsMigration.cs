using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoDriversAndCrewsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Drivers_CoDriverId",
                table: "Crews");

            migrationBuilder.CreateTable(
                name: "CoDriver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoDriver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoDriver_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoDriver",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "Nationality", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonne", "/img/co-drivers/jonne-halttunen.jpg", "Halttunen", "Finland", 1 },
                    { 2, new DateTime(1981, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott", "/img/co-drivers/scott-martin.jpg", "Martin", "United Kingdom", 1 },
                    { 3, new DateTime(1992, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martijn", "/img/co-drivers/martijn-wydaeghe.jpg", "Wydaeghe", "Belgium", 2 },
                    { 4, new DateTime(1987, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", "/img/co-drivers/martin-jarveoja.jpg", "Järveoja", "Estonia", 2 },
                    { 5, new DateTime(1993, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandre", "/img/co-drivers/alexandre-coria.jpg", "Coria", "France", 3 },
                    { 6, new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Louis", "/img/co-drivers/louis-louka.jpg", "Louka", "Belgium", 3 }
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd39efc8-4f70-4250-a655-a7b758ce0f3e", "AQAAAAIAAYagAAAAEMLi4DtS99CpSIqhpCgtU/5ZCaP6ky3gAQMzsIdrj+ayBoUIAT7gHVK0GV6k45Zivw==", "07de0b06-93a2-4bf4-a332-2956cc8eeee9" });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "Id", "CarImageUrl", "CarModel", "CarNumber", "CoDriverId", "DriverId", "TeamId" },
                values: new object[,]
                {
                    { 1, null, "Toyota GR Yaris Rally1", 69, 1, 1, 1 },
                    { 2, null, "Toyota GR Yaris Rally1", 33, 2, 2, 1 },
                    { 3, null, "Hyundai i20 N Rally1", 11, 3, 3, 2 },
                    { 4, null, "Hyundai i20 N Rally1", 8, 4, 4, 2 },
                    { 5, null, "Ford Puma Rally1", 16, 5, 5, 3 },
                    { 6, null, "Ford Puma Rally1", 27, 6, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoDriver_TeamId",
                table: "CoDriver",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_CoDriver_CoDriverId",
                table: "Crews",
                column: "CoDriverId",
                principalTable: "CoDriver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_CoDriver_CoDriverId",
                table: "Crews");

            migrationBuilder.DropTable(
                name: "CoDriver");

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Crews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c2b14b4-c327-47a6-ac5d-5d971749108d", "AQAAAAIAAYagAAAAEBSbJRY6wBanQwxy25V+F5dqhZsLLuXnm8nZ8fT+KTIWZTQbrPNzHjourKp2+kZ5tA==", "c58859e1-3233-4647-b87a-436d0cf2283a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Drivers_CoDriverId",
                table: "Crews",
                column: "CoDriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
