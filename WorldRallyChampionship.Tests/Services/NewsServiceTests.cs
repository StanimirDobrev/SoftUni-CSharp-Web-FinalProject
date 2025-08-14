using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data.Models;
using WorldRallyChampionship.Services.Core;
using WorldRallyChampionship.Tests.Utils;
using WorldRallyChampionship.Web.ViewModels.News;

namespace WorldRallyChampionship.Tests.Services
{
	[TestClass]
	public class NewsServiceTests
	{
		[TestMethod]
		public async Task GetLatestAsync_Takes_Count_And_Sorts_Desc()
		{
			var ctx = TestDb.Create();

			ctx.News.AddRange(
				new News { Id = 101, Title = "Z", Summary = "s", Content = "c", Author = "a", PublishedOn = new DateTime(2025, 3, 1) },
				new News { Id = 102, Title = "Y", Summary = "s", Content = "c", Author = "a", PublishedOn = new DateTime(2025, 3, 2) },
				new News { Id = 103, Title = "X", Summary = "s", Content = "c", Author = "a", PublishedOn = new DateTime(2025, 3, 3) }
			);
			await ctx.SaveChangesAsync();

			var svc = new NewsService(ctx);

			var latest = (await svc.GetLatestAsync(2)).ToList();

			Assert.AreEqual(2, latest.Count);
			Assert.IsTrue(latest[0].PublishedOn >= latest[1].PublishedOn);

			CollectionAssert.AreEqual(
				latest.Select(x => x.PublishedOn).ToList(),
				latest.Select(x => x.PublishedOn).OrderByDescending(d => d).ToList()
			);
		}

		[TestMethod]
		public async Task GetAllAsync_Returns_All_Sorted_Desc()
		{
			var ctx = TestDb.Create();
			var svc = new NewsService(ctx);

			var items = (await svc.GetAllAsync()).ToList();

			Assert.IsTrue(items.Count >= 2);
			var dates = items.Select(x => x.PublishedOn).ToList();
			var sorted = dates.OrderByDescending(d => d).ToList();
			CollectionAssert.AreEqual(sorted, dates);
		}

		[TestMethod]
		public async Task GetByIdAsync_Returns_Details_Or_Null()
		{
			var ctx = TestDb.Create();
			var svc = new NewsService(ctx);

			var found = await svc.GetByIdAsync(1);
			var missing = await svc.GetByIdAsync(9999);

			Assert.IsNotNull(found);
			Assert.AreEqual(1, found!.Id);
			Assert.IsNull(missing);
		}
	}
}
