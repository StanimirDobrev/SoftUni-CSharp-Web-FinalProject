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

		public virtual DbSet<RallyEvent> RallyEvents { get; set; } = null!;
		public virtual DbSet<Driver> Drivers { get; set; } = null!;
		public virtual DbSet<Team> Teams { get; set; } = null!;
		public virtual DbSet<Result> Results { get; set; } = null!;
		public virtual DbSet<Comment> Comments { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


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
			builder.Entity<IdentityUser>().HasData(defaultUser);

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
			
		}
	}
}
