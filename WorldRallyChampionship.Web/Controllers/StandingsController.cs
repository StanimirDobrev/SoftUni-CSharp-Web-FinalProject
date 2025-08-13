using Microsoft.AspNetCore.Mvc;
using WorldRallyChampionship.Services.Core.Contracts;

namespace WorldRallyChampionship.Web.Controllers
{
	public class StandingsController : Controller
	{
		private readonly IStandingsService standings;

		public StandingsController(IStandingsService standings)
		{
			this.standings = standings;
		}

		public async Task<IActionResult> Index()
		{
			var model = await standings.GetRalliesAsync();
			return View(model);
		}

		// /Standings/Details/1
		public async Task<IActionResult> Details(int id)
		{
			var model = await standings.GetRallyResultsAsync(id);
			if (model == null) return NotFound();
			return View(model);
		}
	}
}

