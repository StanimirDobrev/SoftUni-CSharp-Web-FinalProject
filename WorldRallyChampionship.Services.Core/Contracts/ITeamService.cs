using WorldRallyChampionship.Web.ViewModels;
using WorldRallyChampionship.Web.ViewModels.Team;
using WorldRallyChampionship.Web.ViewModels.Common;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface ITeamService
	{
		Task<IEnumerable<TeamViewModel>> GetAllAsync();
		Task<TeamDetailsViewModel?> GetByIdAsync(int id);

		Task<IEnumerable<OptionViewModel>> GetAllOptionsAsync();
	}
}
