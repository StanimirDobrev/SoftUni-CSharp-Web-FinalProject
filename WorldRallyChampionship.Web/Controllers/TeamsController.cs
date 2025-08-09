using Microsoft.AspNetCore.Mvc;
using WorldRallyChampionship.Services.Core.Contracts;

namespace WorldRallyChampionship.Web.Controllers
{
	public class TeamsController : Controller
	{
		private readonly ITeamService teamService;

		public TeamsController(ITeamService teamService)
		{
			this.teamService = teamService;
		}

		public async Task<IActionResult> Index()
		{
			var teams = await teamService.GetAllAsync();
			return View(teams);
		}

		public async Task<IActionResult> Details(int id)
		{
			var team = await teamService.GetByIdAsync(id);
			if (team == null)
			{
				return NotFound();
			}
			return View(team);
		}
	}
}
