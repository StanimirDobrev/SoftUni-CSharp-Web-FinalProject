using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.ViewModels.News;

namespace WorldRallyChampionship.Services.Core
{
	public class NewsService : INewsService
	{
		private readonly ApplicationDbContext db;
		public NewsService(ApplicationDbContext db) => this.db = db;

		public async Task<IEnumerable<NewsListItemViewModel>> GetLatestAsync(int count = 6)
			=> await db.News.OrderByDescending(n => n.PublishedOn).Take(count)
				.Select(n => new NewsListItemViewModel
				{
					Id = n.Id,
					Title = n.Title,
					Summary = n.Summary,
					ImageUrl = n.ImageUrl ?? "/img/placeholder.jpg",
					PublishedOn = n.PublishedOn
				}).ToListAsync();

		public async Task<IEnumerable<NewsListItemViewModel>> GetAllAsync()
			=> await db.News.OrderByDescending(n => n.PublishedOn)
				.Select(n => new NewsListItemViewModel
				{
					Id = n.Id,
					Title = n.Title,
					Summary = n.Summary,
					ImageUrl = n.ImageUrl ?? "/img/placeholder.jpg",
					PublishedOn = n.PublishedOn
				}).ToListAsync();

		public async Task<NewsDetailsViewModel?> GetByIdAsync(int id)
			=> await db.News.Where(n => n.Id == id)
				.Select(n => new NewsDetailsViewModel
				{
					Id = n.Id,
					Title = n.Title,
					Content = n.Content,
					ImageUrl = n.ImageUrl ?? "/img/placeholder.jpg",
					Author = n.Author,
					PublishedOn = n.PublishedOn,
					SourceUrl = n.SourceUrl
				}).FirstOrDefaultAsync();
	}
}
