using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Data.Models;

namespace WorldRallyChampionship.Tests.Utils
{
	public class TestDb : ApplicationDbContext
	{

		public TestDb(DbContextOptions<ApplicationDbContext> options) : base(options) { }


		public DbSet<CoDriver> CoDrivers => Set<CoDriver>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CoDriver>(b =>
			{
				b.ToTable("CoDrivers");
				b.HasKey(x => x.Id);
				b.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
				b.Property(x => x.LastName).IsRequired().HasMaxLength(50);
			});
		}

		public static TestDb Create(string? name = null)
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(name ?? $"WRC_{Guid.NewGuid()}")
				.EnableSensitiveDataLogging()
				.Options;

			var ctx = new TestDb(options);
			Seed(ctx);
			return ctx;
		}

		private static void Seed(TestDb ctx)
		{
			// Предпазване от двойно seed-ване
			if (ctx.Teams.Any()) return;

			var toyota = new Team { Id = 1, Name = "Toyota Gazoo Racing", Manufacturer = "Toyota", LogoUrl = "/img/teams/toyota.jpg" };
			var hyundai = new Team { Id = 2, Name = "Hyundai Shell Mobis", Manufacturer = "Hyundai", LogoUrl = "/img/teams/hyundai.jpg" };
			var ford = new Team { Id = 3, Name = "M-Sport Ford", Manufacturer = "Ford", LogoUrl = "/img/teams/ford.jpg" };
			ctx.Teams.AddRange(toyota, hyundai, ford);

			var d1 = new Driver { Id = 1, FirstName = "Kalle", LastName = "Rovanperä", Nationality = "Finland", TeamId = 1, DateOfBirth = new DateTime(2000, 10, 1) };
			var d2 = new Driver { Id = 2, FirstName = "Elfyn", LastName = "Evans", Nationality = "Wales", TeamId = 1, DateOfBirth = new DateTime(1988, 12, 28) };
			var d3 = new Driver { Id = 3, FirstName = "Thierry", LastName = "Neuville", Nationality = "Belgium", TeamId = 2, DateOfBirth = new DateTime(1988, 6, 16) };
			ctx.Drivers.AddRange(d1, d2, d3);

			// CoDrivers – вече имаме DbSet в TestDb
			var c1 = new CoDriver { Id = 1, FirstName = "Jonne", LastName = "Halttunen", Nationality = "Finland", TeamId = 1, DateOfBirth = new DateTime(1985, 4, 13) };
			var c2 = new CoDriver { Id = 2, FirstName = "Scott", LastName = "Martin", Nationality = "UK", TeamId = 1, DateOfBirth = new DateTime(1981, 11, 6) };
			var c3 = new CoDriver { Id = 3, FirstName = "Martijn", LastName = "Wydaeghe", Nationality = "Belgium", TeamId = 2, DateOfBirth = new DateTime(1992, 9, 1) };
			ctx.CoDrivers.AddRange(c1, c2, c3);

			var crew1 = new Crew { Id = 1, DriverId = 1, CoDriverId = 1, TeamId = 1, CarModel = "Yaris Rally1", CarNumber = 69 };
			var crew2 = new Crew { Id = 2, DriverId = 2, CoDriverId = 2, TeamId = 1, CarModel = "Yaris Rally1", CarNumber = 33 };
			var crew3 = new Crew { Id = 3, DriverId = 3, CoDriverId = 3, TeamId = 2, CarModel = "i20N Rally1", CarNumber = 11 };
			ctx.Crews.AddRange(crew1, crew2, crew3);

			var e1 = new RallyEvent { Id = 1, Name = "Rallye Monte-Carlo", Country = "Monaco/France", Surface = "Tarmac", StartDate = new DateTime(2025, 1, 23), EndDate = new DateTime(2025, 1, 26) };
			var e2 = new RallyEvent { Id = 2, Name = "Rally Sweden", Country = "Sweden", Surface = "Snow", StartDate = new DateTime(2025, 2, 13), EndDate = new DateTime(2025, 2, 16) };
			ctx.RallyEvents.AddRange(e1, e2);

			var s1 = new Standing { Id = 1, RallyEventId = 1, CrewId = 3, Position = 1, Points = 25, TotalTime = "3:14:21.5" };
			var s2 = new Standing { Id = 2, RallyEventId = 1, CrewId = 1, Position = 2, Points = 18, TotalTime = "3:14:45.1" };
			ctx.Standings.AddRange(s1, s2);

			ctx.News.AddRange(
				new News
				{
					Id = 1,
					Title = "Season opener set",
					Summary = "Monte is back.",
					Content = "Long-form article text for Monte...",
					ImageUrl = "/img/news/monte.jpg",
					Author = "WRC Editorial",
					PublishedOn = new DateTime(2025, 1, 10),
					IsFeatured = true
				},
				new News
				{
					Id = 2,
					Title = "Snow battle ahead",
					Summary = "Sweden preview.",
					Content = "Preview article content...",
					ImageUrl = "/img/news/sweden.jpg",
					Author = "Press",
					PublishedOn = new DateTime(2025, 2, 10),
					IsFeatured = false
				}
			);

			ctx.SaveChanges();
		}
	}
}
