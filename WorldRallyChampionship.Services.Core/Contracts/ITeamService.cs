using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface ITeamService
	{
		Task<IEnumerable<OptionViewModel>> GetAllOptionsAsync();
	}
}
