using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Services.Core;
using WorldRallyChampionship.Tests.Utils;
using WorldRallyChampionship.Web.ViewModels.Crew;

namespace WorldRallyChampionship.Tests.Services
{
	public class CrewServiceTests
	{
		[TestMethod]
		public async Task GetAllAsync_Should_Return_Crews_With_Names()
		{
			var ctx = TestDb.Create();
			var sut = new CrewService(ctx);

			var list = (await sut.GetAllAsync()).ToList();

			Assert.IsTrue(list.Count >= 1);
			Assert.IsFalse(string.IsNullOrWhiteSpace(list[0].DriverName));
			Assert.IsFalse(string.IsNullOrWhiteSpace(list[0].CoDriverName));
			Assert.IsFalse(string.IsNullOrWhiteSpace(list[0].TeamName));
		}

		[TestMethod]
		public async Task CreateAsync_Should_Add_Crew()
		{
			var ctx = TestDb.Create();
			var sut = new CrewService(ctx);

			var model = new CrewFormModel
			{
				DriverId = 1,
				CoDriverId = 2,
				TeamId = 1,
				CarModel = "Yaris Rally1",
				CarNumber = 7,
				CarImageUrl = "/img/cars/yaris.jpg"
			};

			var id = await sut.CreateAsync(model);
			var created = await ctx.Crews.FindAsync(id);

			Assert.IsNotNull(created);
			Assert.AreEqual(1, created!.DriverId);
			Assert.AreEqual(1, created.CoDriverId);
			Assert.AreEqual(1, created.TeamId);
		}
	}
}
