using Microsoft.AspNetCore.Mvc;
using WorldRallyChampionship.Services.Core.Contracts;

namespace WorldRallyChampionship.Web.Controllers
{
	public class RallyEventsController : Controller
	{
		private readonly IRallyEventService rallyEventService;

		public RallyEventsController(IRallyEventService rallyEventService)
		{
			this.rallyEventService = rallyEventService;
		}

		public async Task<IActionResult> Index()
		{
			var rallies = await rallyEventService.GetAllAsync();
			return View(rallies);
		}

		public async Task<IActionResult> Details(int id)
		{
			var rally = await rallyEventService.GetByIdAsync(id);
			if (rally == null)
			{
				return NotFound();
			}
			return View(rally);
		}
	}
}
