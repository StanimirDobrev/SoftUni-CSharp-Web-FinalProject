using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldRallyChampionship.Services.Core;
using WorldRallyChampionship.Tests.Utils;

namespace WorldRallyChampionship.Tests.Services
{
	[TestClass]
	public class RallyEventsServiceTests
	{
		[TestMethod]
		public async Task GetAllAsync_Should_Return_Events()
		{
			var ctx = TestDb.Create();
			var sut = new RallyEventService(ctx);

			var list = (await sut.GetAllAsync()).ToList();

			Assert.IsTrue(list.Count >= 2);
			Assert.IsFalse(string.IsNullOrWhiteSpace(list[0].Name));
			Assert.IsFalse(string.IsNullOrWhiteSpace(list[0].Country));
		}

		[TestMethod]
		public async Task GetByIdAsync_Should_Return_Details()
		{
			var ctx = TestDb.Create();
			var sut = new RallyEventService(ctx);

			var vm = await sut.GetByIdAsync(1);

			Assert.IsNotNull(vm);
			Assert.AreEqual("Rallye Monte-Carlo", vm!.Name);
		}
	}
}
