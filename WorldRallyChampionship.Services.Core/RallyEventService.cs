using Microsoft.EntityFrameworkCore;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.RallyEvent;

namespace WorldRallyChampionship.Services.Core
{
	public class RallyEventService : IRallyEventService
	{
		private readonly ApplicationDbContext context;

		public RallyEventService(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<RallyEventViewModel>> GetAllAsync()
		{
			return await context.RallyEvents
				.Select(r => new RallyEventViewModel
				{
					Id = r.Id,
					Name = r.Name,
					Country = r.Country,
					Surface = r.Surface,
					StartDate = r.StartDate,
					EndDate = r.EndDate,
					ImageUrl = r.ImageUrl
				})
				.ToListAsync();
		}

		public async Task<RallyEventDetailsViewModel?> GetByIdAsync(int id)
		{
			return await context.RallyEvents
				.Where(r => r.Id == id)
				.Select(r => new RallyEventDetailsViewModel
				{
					Id = r.Id,
					Name = r.Name,
					Country = r.Country,
					Surface = r.Surface,
					StartDate = r.StartDate,
					EndDate = r.EndDate,
					Description = r.Description,
					ImageUrl = r.ImageUrl
				})
				.FirstOrDefaultAsync();
		}
	}
}
