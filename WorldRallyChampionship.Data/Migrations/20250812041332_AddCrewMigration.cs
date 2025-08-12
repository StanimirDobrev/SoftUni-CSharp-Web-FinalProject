using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldRallyChampionship.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCrewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CoDriverId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarNumber = table.Column<int>(type: "int", nullable: true),
                    CarImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Drivers_CoDriverId",
                        column: x => x.CoDriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crews_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c2b14b4-c327-47a6-ac5d-5d971749108d", "AQAAAAIAAYagAAAAEBSbJRY6wBanQwxy25V+F5dqhZsLLuXnm8nZ8fT+KTIWZTQbrPNzHjourKp2+kZ5tA==", "c58859e1-3233-4647-b87a-436d0cf2283a" });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CoDriverId",
                table: "Crews",
                column: "CoDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_DriverId",
                table: "Crews",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_TeamId",
                table: "Crews",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4390e75-19a2-40dc-892c-aaf9a6767f57", "AQAAAAIAAYagAAAAEOjw0JIitlquqTJy/+yZPQxRsK6qvAFU7aSA0EDy8G78oBTMRRJ2BNXcee4mvxQ2UA==", "08c5ee2a-d0cb-4c86-8b8f-9bd6c78a5294" });
        }
    }
}
