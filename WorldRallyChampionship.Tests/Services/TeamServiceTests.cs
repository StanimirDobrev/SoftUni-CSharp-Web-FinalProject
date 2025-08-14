using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Data.Models;
using WorldRallyChampionship.Services.Core;
using WorldRallyChampionship.Tests.Utils;

namespace WorldRallyChampionship.Tests.Services
{
	public class TeamServiceTests
	{
		[TestMethod]
		public async Task GetAllAsync_Should_Return_Teams()
		{
			var ctx = TestDb.Create();
			ctx.Teams.AddRange(
				new Team { Id = 1, Name = "Toyota", Manufacturer = "Toyota" },
				new Team { Id = 2, Name = "Hyundai", Manufacturer = "Hyundai" }
			);
			await ctx.SaveChangesAsync();

			var service = new TeamService(ctx);
			var list = (await service.GetAllAsync()).ToList();

			Assert.AreEqual(2, list.Count);
			Assert.AreEqual("Toyota", list[0].Name);
		}

		[TestMethod]
		public async Task GetAllOptionsAsync_Should_Return_IdName()
		{
			var ctx = TestDb.Create();
			ctx.Teams.Add(new Team { Id = 10, Name = "M-Sport", Manufacturer = "Ford" });
			await ctx.SaveChangesAsync();

			var service = new TeamService(ctx);
			var opt = (await service.GetAllOptionsAsync()).Single();

			Assert.AreEqual(10, opt.Id);
			Assert.AreEqual("M-Sport", opt.Name);
		}
	}
}
