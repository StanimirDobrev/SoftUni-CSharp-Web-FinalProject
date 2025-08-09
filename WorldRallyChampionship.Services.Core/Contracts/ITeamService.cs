using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels;
using WorldRallyChampionship.Web.ViewModels.Team;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface ITeamService
	{
		Task<IEnumerable<TeamViewModel>> GetAllAsync();
		Task<TeamDetailsViewModel?> GetByIdAsync(int id);

		Task<IEnumerable<OptionViewModel>> GetAllOptionsAsync();
	}
}
