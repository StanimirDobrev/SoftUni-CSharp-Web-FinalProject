using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels;
using WorldRallyChampionship.Web.ViewModels.Team;

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
				.Where(t => t.Id == id)
				.Select(t => new TeamDetailsViewModel
				{
					Id = t.Id,
					Name = t.Name,
					Manufacturer = t.Manufacturer,
					LogoUrl = t.LogoUrl,
					DriverNames = t.Drivers
						.Select(d => d.FirstName + " " + d.LastName)
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
	}
}