using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.Crew;
  

namespace WorldRallyChampionship.Web.Controllers
{
	public class CrewsController : Controller
	{
		private readonly ICrewService crews;
		private readonly IDriverService drivers;
		private readonly ITeamService teams;

		public CrewsController(ICrewService crews, IDriverService drivers, ITeamService teams)
		{
			this.crews = crews;
			this.drivers = drivers;
			this.teams = teams;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
			=> View(await crews.GetAllAsync());

		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			var model = await crews.GetByIdAsync(id);
			return model == null ? NotFound() : View(model);
		}

		[Authorize(Roles = "Administrator")]
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new CrewFormModel
			{
				Drivers = (IEnumerable<ViewModels.Common.OptionViewModel>) await drivers.GetAllOptionsAsync(),
				Teams = await teams.GetAllOptionsAsync()
			};
			return View(model);
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CrewFormModel model)
		{
			if (model.DriverId == model.CoDriverId)
				ModelState.AddModelError(nameof(model.CoDriverId), "Driver и Co-Driver не може да са един и същ.");

			if (!ModelState.IsValid)
			{
				model.Drivers = (IEnumerable<ViewModels.Common.OptionViewModel>)await drivers.GetAllOptionsAsync();
				model.Teams = await teams.GetAllOptionsAsync();
				return View(model);
			}

			var id = await crews.CreateAsync(model);
			return RedirectToAction(nameof(Details), new { id });
		}
	}
}
