using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels.RallyEvent;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface IRallyEventService
	{
		Task<IEnumerable<RallyEventViewModel>> GetAllAsync();
		Task<RallyEventDetailsViewModel?> GetByIdAsync(int id);
	}
}
