using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Standing;

namespace WorldRallyChampionship.Services.Core
{
	public class StandingsService : IStandingsService
	{
		private readonly ApplicationDbContext context;

		public StandingsService(ApplicationDbContext context) => this.context = context;

		public async Task<IEnumerable<RallyListItemViewModel>> GetRalliesAsync()
			=> await context.RallyEvents
				.Select(r => new RallyListItemViewModel
				{
					Id = r.Id,
					Name = r.Name,
					Country = r.Country,
					Surface = r.Surface,
					StartDate = r.StartDate,
					HasResults = context.Standings.Any(x => x.RallyEventId == r.Id)
				})
				.OrderBy(r => r.StartDate)
				.ToListAsync();

		public async Task<RallyResultsViewModel?> GetRallyResultsAsync(int rallyId)
		{
			var rally = await context.RallyEvents.FirstOrDefaultAsync(r => r.Id == rallyId);
			if (rally == null) return null;

			var rows = await context.Standings
				.Where(x => x.RallyEventId == rallyId)
				.Include(x => x.Crew).ThenInclude(c => c.Driver)
				.Include(x => x.Crew).ThenInclude(c => c.CoDriver)
				.Include(x => x.Crew).ThenInclude(c => c.Team)
				.OrderBy(x => x.Position)
				.Select(x => new StandingRowViewModel
				{
					Position = x.Position,
					DriverName = x.Crew.Driver.FirstName + " " + x.Crew.Driver.LastName,
					CoDriverName = x.Crew.CoDriver.FirstName + " " + x.Crew.CoDriver.LastName,
					TeamName = x.Crew.Team.Name,
					CarModel = x.Crew.CarModel,
					CarNumber = x.Crew.CarNumber,
					TotalTime = x.TotalTime,
					DiffToLeader = string.IsNullOrWhiteSpace(x.DiffToLeader) ? "—" : x.DiffToLeader,
					Points = x.Points,
					PowerStagePoints = x.PowerStagePoints
				})
				.ToListAsync();

			return new RallyResultsViewModel
			{
				RallyId = rally.Id,
				RallyName = rally.Name,
				Country = rally.Country,
				StartDate = rally.StartDate,
				EndDate = rally.EndDate,
				Surface = rally.Surface,
				ImageUrl = rally.ImageUrl,
				Rows = rows
			};
		}
	}
}
