
using WorldRallyChampionship.Web.ViewModels.Driver;

namespace WorldRallyChampionship.Services.Core.Contracts
{
	public interface IDriverService
	{
		public Task<IEnumerable<DriverViewModel>> GetAllAsync();
		public Task<DriverDetailsViewModel?> GetByIdAsync(int id);
		public Task<int> CreateAsync(DriverFormModel model);
		public Task<bool> UpdateAsync(int id, DriverFormModel model);
		public Task<bool> DeleteAsync(int id);
	}
}
