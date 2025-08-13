using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStandingsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01", "7699db7d-964f-4782-8209-d76562e0fece" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01");

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RallyEventId = table.Column<int>(type: "int", nullable: false),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DiffToLeader = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    PowerStagePoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standings_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standings_RallyEvents_RallyEventId",
                        column: x => x.RallyEventId,
                        principalTable: "RallyEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Standings",
                columns: new[] { "Id", "CrewId", "DiffToLeader", "Points", "Position", "PowerStagePoints", "RallyEventId", "TotalTime" },
                values: new object[,]
                {
                    { 1, 3, "", 25, 1, 5, 1, "3:26:18.4" },
                    { 2, 2, "+10.3", 18, 2, 4, 1, "3:26:28.7" },
                    { 3, 5, "+51.7", 15, 3, 3, 1, "3:27:10.1" },
                    { 4, 2, "", 25, 1, 3, 2, "2:43:02.0" },
                    { 5, 4, "+8.6", 18, 2, 5, 2, "2:43:10.6" },
                    { 6, 6, "+42.3", 15, 3, 2, 2, "2:43:44.3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Standings_CrewId",
                table: "Standings",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_RallyEventId",
                table: "Standings",
                column: "RallyEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7699db7d-964f-4782-8209-d76562e0fece", 0, "42ae65bd-7807-4b4a-a7c1-451e2a2c69f9", "admin@horizons.com", true, false, null, "ADMIN@HORIZONS.COM", "ADMIN@HORIZONS.COM", "AQAAAAIAAYagAAAAEFnW1f+n0sBgn6rw/tabeRDnbNtgtNMB5oiV48owqe8UKIUFgwIqC4g2gUz69dW8aw==", null, false, "f89b3256-fb32-4a98-aa09-3a1c316993ab", false, "admin@horizons.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01", "7699db7d-964f-4782-8209-d76562e0fece" });
        }
    }
}
