using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Crew;

namespace WorldRallyChampionship.Services.Core
{
	public class CrewService : ICrewService
	{
		private readonly ApplicationDbContext dbContext;
		public CrewService(ApplicationDbContext db) => this.dbContext = db;

		public async Task<IEnumerable<CrewViewModel>> GetAllAsync()
			=> await dbContext.Crews
				.Include(c => c.Driver).Include(c => c.CoDriver).Include(c => c.Team)
				.OrderBy(c => c.Team.Name).ThenBy(c => c.CarNumber ?? int.MaxValue)
				.Select(c => new CrewViewModel
				{
					Id = c.Id,
					DriverId = c.DriverId,
					CoDriverId = c.CoDriverId,
					TeamId = c.TeamId,
					DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
					CoDriverName = c.CoDriver.FirstName + " " + c.CoDriver.LastName,
					TeamName = c.Team.Name,
					DriverImageUrl = string.IsNullOrWhiteSpace(c.Driver.ImageUrl) ? "/img/placeholder.jpg" : c.Driver.ImageUrl,
					CoDriverImageUrl = string.IsNullOrWhiteSpace(c.CoDriver.ImageUrl) ? "/img/placeholder.jpg" : c.CoDriver.ImageUrl,
					CarModel = c.CarModel,
					CarNumber = c.CarNumber,
					CarImageUrl = c.CarImageUrl
				})
				.ToListAsync();

		public async Task<CrewViewModel?> GetByIdAsync(int id)
			=> await dbContext.Crews
				.Include(c => c.Driver).Include(c => c.CoDriver).Include(c => c.Team)
				.Where(c => c.Id == id)
				.Select(c => new CrewViewModel
				{
					Id = c.Id,
					DriverId = c.DriverId,
					CoDriverId = c.CoDriverId,
					TeamId = c.TeamId,
					DriverName = c.Driver.FirstName + " " + c.Driver.LastName,
					CoDriverName = c.CoDriver.FirstName + " " + c.CoDriver.LastName,
					TeamName = c.Team.Name,
					DriverImageUrl = c.Driver.ImageUrl ?? "/img/placeholder.jpg",
					CoDriverImageUrl = c.CoDriver.ImageUrl ?? "/img/placeholder.jpg",
					CarModel = c.CarModel,
					CarNumber = c.CarNumber,
					CarImageUrl = c.CarImageUrl
				})
				.FirstOrDefaultAsync();

		public async Task<int> CreateAsync(CrewFormModel m)
		{
			if (m.DriverId == m.CoDriverId)
				throw new ArgumentException("Driver и Co-Driver не може да са един и същ.");

			var exists = await dbContext.Drivers.AnyAsync(d => d.Id == m.DriverId) &&
						 await dbContext.Drivers.AnyAsync(d => d.Id == m.CoDriverId) &&
						 await dbContext.Teams.AnyAsync(t => t.Id == m.TeamId);

			if (!exists) throw new ArgumentException("Невалидни Driver/Co-Driver/Team.");

			var entity = new Data.Models.Crew
			{
				DriverId = m.DriverId,
				CoDriverId = m.CoDriverId,
				TeamId = m.TeamId,
				CarModel = m.CarModel,
				CarNumber = m.CarNumber,
				CarImageUrl = m.CarImageUrl
			};

			dbContext.Crews.Add(entity);
			await dbContext.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var e = await dbContext.Crews.FindAsync(id);
			if (e == null) return false;
			dbContext.Crews.Remove(e);
			await dbContext.SaveChangesAsync();
			return true;
		}
	}
}
