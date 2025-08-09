using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Driver;

namespace WorldRallyChampionship.Web.Controllers
{
	public class DriverController : Controller
	{
		private readonly IDriverService _driverService;
		private readonly ITeamService _teamService;

		public DriverController(IDriverService driverService, ITeamService teamService)
		{
			_driverService = driverService;
			_teamService = teamService;
		}

		public async Task<IActionResult> Index()
		{
			var drivers = await _driverService.GetAllAsync();
			return View(drivers);
		}

		public async Task<IActionResult> Details(int id)
		{
			var driver = await _driverService.GetByIdAsync(id);
			if (driver == null) return NotFound();
			return View(driver);
		}

		public async Task<IActionResult> Create()
		{
			await PopulateTeams();
			return View(new DriverFormModel { DateOfBirth = DateTime.UtcNow.AddYears(-25) });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DriverFormModel model)
		{
			if (!ModelState.IsValid)
			{
				await PopulateTeams();
				return View(model);
			}

			await _driverService.CreateAsync(model);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var driver = await _driverService.GetByIdAsync(id);
			if (driver == null) return NotFound();

			var model = new DriverFormModel
			{
				FirstName = driver.FirstName,
				LastName = driver.LastName,
				Nationality = driver.Nationality,
				DateOfBirth = driver.DateOfBirth,
				// TODO: трябва ти TeamId – можеш да разшириш Details VM да връща и TeamId
			};

			await PopulateTeams(/*selectedId: model.TeamId*/);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, DriverFormModel model)
		{
			if (!ModelState.IsValid)
			{
				await PopulateTeams(/*selectedId: model.TeamId*/);
				return View(model);
			}

			await _driverService.UpdateAsync(id, model);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			var driver = await _driverService.GetByIdAsync(id);
			if (driver == null) return NotFound();
			return View(driver);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _driverService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private async Task PopulateTeams(int? selectedId = null)
		{
			var options = await _teamService.GetAllOptionsAsync();
			ViewBag.Teams = new SelectList(options, "Value", "Text", selectedId);
		}
	}
}