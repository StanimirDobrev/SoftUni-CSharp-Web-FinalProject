using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels.Crew;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface ICrewService
	{
		Task<IEnumerable<CrewViewModel>> GetAllAsync();
		Task<CrewViewModel?> GetByIdAsync(int id);
		Task<int> CreateAsync(CrewFormModel model);
		Task<bool> DeleteAsync(int id);
	}
}
