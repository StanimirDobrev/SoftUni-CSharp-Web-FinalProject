using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data.Models;

namespace WorldRallyChampionship.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		public virtual DbSet<Standing> Standings { get; set; } = null!;
		public virtual DbSet<RallyEvent> RallyEvents { get; set; } = null!;
		public virtual DbSet<Driver> Drivers { get; set; } = null!;
		public virtual DbSet<Team> Teams { get; set; } = null!;
		public virtual DbSet<Result> Results { get; set; } = null!;
		public virtual DbSet<Comment> Comments { get; set; } = null!;
		public virtual DbSet<News> News { get; set; } = null!;
		public virtual DbSet<Crew> Crews { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			

			builder.Entity<Crew>()
				.HasOne(c => c.Driver)
				.WithMany()		
				.HasForeignKey(c => c.DriverId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Crew>()
				.HasOne(c => c.CoDriver)
				.WithMany()
				.HasForeignKey(c => c.CoDriverId)
				.OnDelete(DeleteBehavior.Restrict);


			builder.Entity<Comment>()
				.HasOne(c => c.RallyEvent)
				.WithMany(r => r.Comments)
				.HasForeignKey(c => c.RallyEventId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Comment>()
				.HasOne(c => c.Driver)
				.WithMany(d => d.Comments)
				.HasForeignKey(c => c.DriverId)
				.OnDelete(DeleteBehavior.Restrict);

			var defaultUser = new IdentityUser
			{
				Id = "7699db7d-964f-4782-8209-d76562e0fece",
				UserName = "admin@horizons.com",
				NormalizedUserName = "ADMIN@HORIZONS.COM",
				Email = "admin@horizons.com",
				NormalizedEmail = "ADMIN@HORIZONS.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
				new IdentityUser { UserName = "admin@horizons.com" },
				"Admin123!")
			};


			// Teams
			builder.Entity<Team>().HasData(
				new Team { Id = 1, Name = "Toyota Gazoo Racing", Manufacturer = "Toyota", LogoUrl = "/img/teams/toyota.jpg" },
				new Team { Id = 2, Name = "Hyundai Shell Mobis", Manufacturer = "Hyundai", LogoUrl = "/img/teams/hyundai.jpg" },
				new Team { Id = 3, Name = "M-Sport Ford", Manufacturer = "Ford", LogoUrl = "/img/teams/m-sport ford.jpg" }
			);

			// Drivers
			builder.Entity<Driver>().HasData(
				new Driver { Id = 1, FirstName = "Kalle", LastName = "Rovanperä", Nationality = "Finland", DateOfBirth = new DateTime(2000, 10, 1), TeamId = 1, ImageUrl = "/img/drivers/kalle-rovampera.jpg" },
				new Driver { Id = 2, FirstName = "Elfyn", LastName = "Evans", Nationality = "Wales", DateOfBirth = new DateTime(1988, 12, 28), TeamId = 1, ImageUrl = "/img/drivers/elfyn-evans.jpg" },
				new Driver { Id = 3, FirstName = "Thierry", LastName = "Neuville", Nationality = "Belgium", DateOfBirth = new DateTime(1988, 6, 16), TeamId = 2, ImageUrl = "/img/drivers/thierry-neuville.jpg" },
				new Driver { Id = 4, FirstName = "Ott", LastName = "Tänak", Nationality = "Estonia", DateOfBirth = new DateTime(1987, 10, 15), TeamId = 2, ImageUrl = "/img/drivers/ott-tanak.jpg" },
				new Driver { Id = 5, FirstName = "Adrien", LastName = "Fourmaux", Nationality = "France", DateOfBirth = new DateTime(1995, 5, 3), TeamId = 3, ImageUrl = "/img/drivers/adrien-fourmaux.jpg" },
				new Driver { Id = 6, FirstName = "Grégoire", LastName = "Munster", Nationality = "Luxembourg", DateOfBirth = new DateTime(1998, 3, 24), TeamId = 3, ImageUrl = "/img/drivers/gregoire-munster.jpg" }
			);

			// Rally events
			builder.Entity<RallyEvent>().HasData(
				new RallyEvent
				{
					Id = 1,
					Name = "Rallye Monte-Carlo",
					Country = "Monaco / France",
					StartDate = new DateTime(2025, 1, 23),
					EndDate = new DateTime(2025, 1, 26),
					Surface = "Tarmac",
					Description = "Legendary winter tarmac rally.",
					ImageUrl = "/img/rallies/rallye-monte-carlo-2025.jpg"
				},
				new RallyEvent
				{
					Id = 2,
					Name = "Rally Sweden",
					Country = "Sweden",
					StartDate = new DateTime(2025, 2, 13),
					EndDate = new DateTime(2025, 2, 16),
					Surface = "Snow",
					Description = "Fast snow stages with snowbanks.",
					ImageUrl = "/img/rallies/wrc-rally-sweden-2025.jpg"
				},
				new RallyEvent
				{
					Id = 3,
					Name = "Croatia Rally",
					Country = "Croatia",
					StartDate = new DateTime(2025, 4, 10),
					EndDate = new DateTime(2025, 4, 13),
					Surface = "Tarmac",
					Description = "Technical tarmac with tricky cuts.",
					ImageUrl = "/img/rallies/croatia-rally-2025.jpg"
				});

			//News

			builder.Entity<News>().HasData(
				new News
				{
					Id = 1,
					Title = "Rallye Monte-Carlo: Opening Round Confirmed",
					Summary = "Iconic season opener returns with night stages and tight mountain passes.",
					Content = "Full article content here...",
					ImageUrl = "/img/news/monte.jpg",
					SourceUrl = "https://example.com/monte",
					Author = "WRC Editorial",
					PublishedOn = new DateTime(2025, 1, 10),
					IsFeatured = true
				},
				new News
				{
					Id = 2,
					Title = "Evans vs Neuville: Early Title Fight",
					Summary = "Point gap narrows after dramatic Power Stage.",
					Content = "Full article content here...",
					ImageUrl = "/img/news/fight.jpg",
					Author = "Press",
					PublishedOn = new DateTime(2025, 2, 2),
					IsFeatured = true
				}
				);

			// CoDrivers
			builder.Entity<CoDriver>().HasData(
				new CoDriver { Id = 1, FirstName = "Jonne", LastName = "Halttunen", Nationality = "Finland", DateOfBirth = new DateTime(1985, 12, 13), TeamId = 1, ImageUrl = "/img/co-drivers/jonne-halttunen.jpg" },
				new CoDriver { Id = 2, FirstName = "Scott", LastName = "Martin", Nationality = "United Kingdom", DateOfBirth = new DateTime(1981, 11, 6), TeamId = 1, ImageUrl = "/img/co-drivers/scott-martin.jpg" },
				new CoDriver { Id = 3, FirstName = "Martijn", LastName = "Wydaeghe", Nationality = "Belgium", DateOfBirth = new DateTime(1992, 9, 1), TeamId = 2, ImageUrl = "/img/co-drivers/martijn-wydaeghe.jpg" },
				new CoDriver { Id = 4, FirstName = "Martin", LastName = "Järveoja", Nationality = "Estonia", DateOfBirth = new DateTime(1987, 8, 18), TeamId = 2, ImageUrl = "/img/co-drivers/martin-jarveoja.jpg" },
				new CoDriver { Id = 5, FirstName = "Alexandre", LastName = "Coria", Nationality = "France", DateOfBirth = new DateTime(1993, 1, 15), TeamId = 3, ImageUrl = "/img/co-drivers/alexandre-coria.jpg" },
				new CoDriver { Id = 6, FirstName = "Louis", LastName = "Louka", Nationality = "Belgium", DateOfBirth = new DateTime(1998, 2, 26), TeamId = 3, ImageUrl = "/img/co-drivers/louis-louka.jpg" }
			);

			// Crews
			builder.Entity<Crew>().HasData(
				new Crew { Id = 1, DriverId = 1, CoDriverId = 1, TeamId = 1, CarModel = "Toyota GR Yaris Rally1", CarNumber = 69},
				new Crew { Id = 2, DriverId = 2, CoDriverId = 2, TeamId = 1, CarModel = "Toyota GR Yaris Rally1", CarNumber = 33},
				new Crew { Id = 3, DriverId = 3, CoDriverId = 3, TeamId = 2, CarModel = "Hyundai i20 N Rally1", CarNumber = 11},
				new Crew { Id = 4, DriverId = 4, CoDriverId = 4, TeamId = 2, CarModel = "Hyundai i20 N Rally1", CarNumber = 8},
				new Crew { Id = 5, DriverId = 5, CoDriverId = 5, TeamId = 3, CarModel = "Ford Puma Rally1", CarNumber = 16},
				new Crew { Id = 6, DriverId = 6, CoDriverId = 6, TeamId = 3, CarModel = "Ford Puma Rally1", CarNumber = 27}
			);

			//Standings
			builder.Entity<Standing>().HasData(
				// Monte-Carlo
				new Standing { Id = 1, RallyEventId = 1, CrewId = 3, Position = 1, TotalTime = "3:26:18.4", DiffToLeader = "", Points = 25, PowerStagePoints = 5 }, // Neuville/Wydaeghe
				new Standing { Id = 2, RallyEventId = 1, CrewId = 2, Position = 2, TotalTime = "3:26:28.7", DiffToLeader = "+10.3", Points = 18, PowerStagePoints = 4 }, // Evans/Martin
				new Standing { Id = 3, RallyEventId = 1, CrewId = 5, Position = 3, TotalTime = "3:27:10.1", DiffToLeader = "+51.7", Points = 15, PowerStagePoints = 3 }, // Fourmaux/Coria

				// Sweden
				new Standing { Id = 4, RallyEventId = 2, CrewId = 2, Position = 1, TotalTime = "2:43:02.0", DiffToLeader = "", Points = 25, PowerStagePoints = 3 },
				new Standing { Id = 5, RallyEventId = 2, CrewId = 4, Position = 2, TotalTime = "2:43:10.6", DiffToLeader = "+8.6", Points = 18, PowerStagePoints = 5 },
				new Standing { Id = 6, RallyEventId = 2, CrewId = 6, Position = 3, TotalTime = "2:43:44.3", DiffToLeader = "+42.3", Points = 15, PowerStagePoints = 2 }
			);
		}
	}
}
