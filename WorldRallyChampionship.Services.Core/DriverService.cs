using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Data.Models;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Driver;

namespace WorldRallyChampionship.Services.Core
{
	public class DriverService : IDriverService
	{
		private readonly ApplicationDbContext context;

		public DriverService(ApplicationDbContext context)
			=> this.context = context;

		public async Task<IEnumerable<DriverViewModel>> GetAllAsync()
		{
			return await context.Drivers
				.AsNoTracking()
				.Include(d => d.Team)
				.OrderBy(d => d.LastName).ThenBy(d => d.FirstName)
				.Select(d => new DriverViewModel
				{
					Id = d.Id,
					FullName = d.FirstName + " " + d.LastName,
					Nationality = d.Nationality,
					TeamName = d.Team.Name
				})
				.ToListAsync();
		}

		public async Task<DriverDetailsViewModel?> GetByIdAsync(int id)
		{
			return await context.Drivers
				.AsNoTracking()
				.Include(d => d.Team)
				.Where(d => d.Id == id)
				.Select(d => new DriverDetailsViewModel
				{
					Id = d.Id,
					FirstName = d.FirstName,
					LastName = d.LastName,
					Nationality = d.Nationality,
					DateOfBirth = d.DateOfBirth,
					TeamName = d.Team.Name
				})
				.FirstOrDefaultAsync();
		}

		public async Task<int> CreateAsync(DriverFormModel model)
		{
			var teamExists = await context.Teams.AnyAsync(t => t.Id == model.TeamId);
			if (!teamExists) throw new ArgumentException("Invalid team.");

			var driver = new Driver
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Nationality = model.Nationality,
				DateOfBirth = model.DateOfBirth,
				TeamId = model.TeamId
			};

			await context.Drivers.AddAsync(driver);
			await context.SaveChangesAsync();
			return driver.Id;
		}

		public async Task<bool> UpdateAsync(int id, DriverFormModel model)
		{
			var driver = await context.Drivers.FindAsync(id);
			if (driver == null) return false;

			var teamExists = await context.Teams.AnyAsync(t => t.Id == model.TeamId);
			if (!teamExists) throw new ArgumentException("Invalid team.");

			driver.FirstName = model.FirstName;
			driver.LastName = model.LastName;
			driver.Nationality = model.Nationality;
			driver.DateOfBirth = model.DateOfBirth;
			driver.TeamId = model.TeamId;

			await context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var driver = await context.Drivers.FindAsync(id);
			if (driver == null) return false;

			context.Drivers.Remove(driver);
			await context.SaveChangesAsync();
			return true;
		}
	}
}
