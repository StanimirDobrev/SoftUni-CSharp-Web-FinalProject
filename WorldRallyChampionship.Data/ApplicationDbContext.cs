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
		}
	}
}
