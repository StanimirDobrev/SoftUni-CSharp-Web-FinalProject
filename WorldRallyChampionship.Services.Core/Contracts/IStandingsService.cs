using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels.Standing;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface IStandingsService
	{
		Task<IEnumerable<RallyListItemViewModel>> GetRalliesAsync();
		Task<RallyResultsViewModel?> GetRallyResultsAsync(int rallyId);
	}
}
