using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorldRallyChampionship.Web.Controllers;
using WorldRallyChampionship.Web.ViewModels;


namespace WorldRallyChampionship.Web.Controllers
{

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return RedirectToAction("Index", "RallyEvents");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
