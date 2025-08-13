using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels;
using WorldRallyChampionship.Web.ViewModels.Driver;
using WorldRallyChampionship.Web.ViewModels.Team;
using WorldRallyChampionship.Web.ViewModels.Common;

namespace WorldRallyChampionship.Services.Core
{
	public class TeamService : ITeamService
	{
		private readonly ApplicationDbContext context;

		public TeamService(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<TeamViewModel>> GetAllAsync()
		{
			return await context.Teams
				.Select(t => new TeamViewModel
				{
					Id = t.Id,
					Name = t.Name,
					Manufacturer = t.Manufacturer,
					LogoUrl = t.LogoUrl
				})
				.ToListAsync();
		}

		public async Task<TeamDetailsViewModel?> GetByIdAsync(int id)
		{
			return await context.Teams
				.Include(t => t.Drivers)
				.Where(t => t.Id == id)
				.Select(t => new TeamDetailsViewModel
				{
					Id = t.Id,
					Name = t.Name,
					Manufacturer = t.Manufacturer,
					LogoUrl = t.LogoUrl,

					Drivers = t.Drivers
						.OrderBy(d => d.LastName)
						.Select(d => new DriverViewModel
						{
							Id = d.Id,
							FullName = d.FirstName + " " + d.LastName,
							Nationality = d.Nationality,
							TeamName = t.Name,
							ImageUrl = string.IsNullOrWhiteSpace(d.ImageUrl) ? "/img/placeholder.jpg" : d.ImageUrl
						})
						.ToList()
				})
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<OptionViewModel>> GetAllOptionsAsync()
		{
			return await context.Teams
				.Select(t => new OptionViewModel
				{
					Id = t.Id,
					Name = t.Name
				})
				.ToListAsync();
		}

		public async Task<TeamDetailsViewModel?> GetDetailsAsync(int id)
		{
			return await context.Teams
				.Include(t => t.Drivers)
				.Where(t => t.Id == id)
				.Select(t => new TeamDetailsViewModel
				{
					Id = t.Id,
					Name = t.Name,
					Manufacturer = t.Manufacturer,
					LogoUrl = string.IsNullOrWhiteSpace(t.LogoUrl) ? "/img/placeholder.jpg" : t.LogoUrl,
					Drivers = t.Drivers
						.OrderBy(d => d.LastName)
						.Select(d => new DriverViewModel
						{
							Id = d.Id,
							FullName = d.FirstName + " " + d.LastName,
							Nationality = d.Nationality,
							TeamName = t.Name,
							ImageUrl = string.IsNullOrWhiteSpace(d.ImageUrl) ? "/img/placeholder.jpg" : d.ImageUrl
						})
						.ToList()
				})
				.FirstOrDefaultAsync();
		}
	}
}