using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Web.ViewModels.News;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface INewsService
	{
		Task<IEnumerable<NewsListItemViewModel>> GetLatestAsync(int count = 6);
		Task<IEnumerable<NewsListItemViewModel>> GetAllAsync();
		Task<NewsDetailsViewModel?> GetByIdAsync(int id);
	}
}
