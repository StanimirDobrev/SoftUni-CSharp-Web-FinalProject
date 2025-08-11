using Microsoft.AspNetCore.Mvc;
using WorldRallyChampionship.Services.Core.Contracts;

namespace WorldRallyChampionship.Web.Controllers
{
	public class NewsController : Controller
	{
		private readonly INewsService news;
		public NewsController(INewsService news) => this.news = news;

		public async Task<IActionResult> Index()
			=> View(await news.GetAllAsync());

		public async Task<IActionResult> Details(int id)
		{
			var model = await news.GetByIdAsync(id);
			return model == null ? NotFound() : View(model);
		}
	}
}
