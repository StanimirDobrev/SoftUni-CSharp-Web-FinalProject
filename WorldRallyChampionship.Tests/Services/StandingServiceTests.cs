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
	public class StandingServiceTests
	{
		[TestMethod]
		public async Task GetRalliesAsync_Returns_All_With_HasResults_Flag()
		{
			// Arrange
			var ctx = TestDb.Create();
			var svc = new StandingsService(ctx);

			// Act
			var rallies = (await svc.GetRalliesAsync()).ToList();

			// Assert
			Assert.IsTrue(rallies.Count >= 2, "Очаквахме поне 2 ралита от seed-а.");

			var mc = rallies.First(r => r.Id == 1); // Monte
			var se = rallies.First(r => r.Id == 2); // Sweden

			Assert.IsTrue(mc.HasResults, "Monte трябва да има резултати (Standings).");
			Assert.IsFalse(se.HasResults, "Sweden не трябва да има резултати (гол seed).");

			var ordered = rallies.OrderBy(r => r.StartDate).Select(r => r.Id).ToList();
			CollectionAssert.AreEqual(ordered, rallies.Select(r => r.Id).ToList());
		}

		[TestMethod]
		public async Task GetRallyResultsAsync_Returns_Rows_Ordered_And_Mapped()
		{
			// Arrange
			var ctx = TestDb.Create();
			var svc = new StandingsService(ctx);

			// Act
			var vm = await svc.GetRallyResultsAsync(1); 

			// Assert
			Assert.IsNotNull(vm, "Резултатите за Monte не трябва да са null.");
			Assert.AreEqual(1, vm!.RallyId);
			Assert.IsTrue(vm.Rows.Any(), "Трябва да има редове в таблицата.");


			var ordered = vm.Rows.Select(x => x.Position).ToList();
			var sorted = ordered.OrderBy(x => x).ToList();
			CollectionAssert.AreEqual(sorted, ordered);

			var leader = vm.Rows.First();
			Assert.AreEqual(1, leader.Position);
			StringAssert.Contains(leader.DriverName, "Thierry");
			StringAssert.Contains(leader.TeamName, "Hyundai");
			Assert.IsFalse(string.IsNullOrWhiteSpace(leader.TotalTime));
		}

		[TestMethod]
		public async Task GetRallyResultsAsync_Returns_Null_When_Rally_NotFound()
		{
			// Arrange
			var ctx = TestDb.Create();
			var svc = new StandingsService(ctx);

			// Act
			var vm = await svc.GetRallyResultsAsync(9999);

			// Assert
			Assert.IsNull(vm);
		}
	}
}
