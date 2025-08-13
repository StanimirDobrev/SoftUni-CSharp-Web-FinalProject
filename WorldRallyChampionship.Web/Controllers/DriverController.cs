using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Driver;

namespace WorldRallyChampionship.Web.Controllers
{
	// URL-овете ще са /Drivers/...
	public class DriverController : Controller
	{
		private readonly IDriverService _driverService;
		private readonly ITeamService _teamService;

		public DriverController(IDriverService driverService, ITeamService teamService)
		{
			_driverService = driverService;
			_teamService = teamService;
		}

		private async Task PopulateTeamsAsync(int? selectedId = null)
		{
			// ВАЖНО: ITeamService.GetAllOptionsAsync да връща единния OptionViewModel (Web.ViewModels.Common)
			var options = await _teamService.GetAllOptionsAsync();
			ViewBag.Teams = new SelectList(options, "Id", "Name", selectedId);
		}

		// GET: /Drivers
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var drivers = await _driverService.GetAllAsync();
			return View(drivers);
		}

		// GET: /Drivers/Details/5
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await _driverService.GetByIdAsync(id);
			if (model == null) return NotFound();
			return View(model);
		}

		// GET: /Drivers/Create
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			await PopulateTeamsAsync();
			// По избор – default стойности
			return View(new DriverFormModel
			{
				DateOfBirth = DateTime.UtcNow.AddYears(-25)
			});
		}

		// POST: /Drivers/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DriverFormModel model)
		{
			if (!ModelState.IsValid)
			{
				await PopulateTeamsAsync(model.TeamId);
				return View(model);
			}

			try
			{
				var newId = await _driverService.CreateAsync(model);
				return RedirectToAction(nameof(Details), new { id = newId });
			}
			catch (ArgumentException ex)
			{
				// напр. "Invalid team."
				ModelState.AddModelError(string.Empty, ex.Message);
				await PopulateTeamsAsync(model.TeamId);
				return View(model);
			}
		}

		// GET: /Drivers/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			// Нужен ни е TeamId => взимаме форма-модела от сервиса
			var formModel = await _driverService.GetFormByIdAsync(id);
			if (formModel == null) return NotFound();

			await PopulateTeamsAsync(formModel.TeamId);
			return View(formModel);
		}

		// POST: /Drivers/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, DriverFormModel model)
		{
			if (id != model.Id) return BadRequest();

			if (!ModelState.IsValid)
			{
				await PopulateTeamsAsync(model.TeamId);
				return View(model);
			}

			try
			{
				var ok = await _driverService.UpdateAsync(id, model);
				if (!ok) return NotFound();

				return RedirectToAction(nameof(Details), new { id });
			}
			catch (ArgumentException ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				await PopulateTeamsAsync(model.TeamId);
				return View(model);
			}
		}

		// GET: /Drivers/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var model = await _driverService.GetByIdAsync(id);
			if (model == null) return NotFound();
			return View(model);
		}

		// POST: /Drivers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var ok = await _driverService.DeleteAsync(id);
			if (!ok) return NotFound();
			return RedirectToAction(nameof(Index));
		}
	}
}
