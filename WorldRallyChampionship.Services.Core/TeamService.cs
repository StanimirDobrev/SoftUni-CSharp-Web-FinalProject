using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels;

namespace WorldRallyChampionship.Services.Core
{
	public class TeamService : ITeamService
	{
		private readonly ApplicationDbContext _db;
		public TeamService(ApplicationDbContext db) => _db = db;

		public async Task<IEnumerable<OptionViewModel>> GetAllOptionsAsync()
		{
			return await _db.Teams
				.AsNoTracking()
				.OrderBy(t => t.Name)
				.Select(t => new OptionViewModel { Value = t.Id, Text = t.Name })
				.ToListAsync();
		}
	}
}
