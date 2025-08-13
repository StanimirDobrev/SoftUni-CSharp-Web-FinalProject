using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldRallyChampionship.Data.Migrations
{
	public partial class SeedAdminRole : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [NormalizedName] = 'ADMINISTRATOR')
BEGIN
    INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES ('f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01', 'Administrator', 'ADMINISTRATOR', NEWID())
END
");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
DELETE FROM [AspNetRoles]
WHERE [Id] = 'f2c4d3a1-bb93-4b29-bd38-9e98d60f6f01'
");
		}
	}
}