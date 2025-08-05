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

		public DbSet<RallyEvent> RallyEvents { get; set; } = null!;
		public DbSet<Driver> Drivers { get; set; } = null!;
		public DbSet<Team> Teams { get; set; } = null!;
		public DbSet<Result> Results { get; set; } = null!;
		public DbSet<Comment> Comments { get; set; } = null!;

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
		}
	}
}
