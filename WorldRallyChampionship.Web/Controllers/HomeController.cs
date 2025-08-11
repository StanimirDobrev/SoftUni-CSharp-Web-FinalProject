using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.Controllers;
using WorldRallyChampionship.Web.ViewModels;


namespace WorldRallyChampionship.Web.Controllers
{

	public class HomeController : Controller
	{
		private readonly INewsService news;

		public HomeController(INewsService news)
			=> this.news = news;

		public async Task<IActionResult> Index()
		{
			var latest = await news.GetLatestAsync(3); 
			return View(latest); 
		}

		public IActionResult Privacy() => View();
	}
}
