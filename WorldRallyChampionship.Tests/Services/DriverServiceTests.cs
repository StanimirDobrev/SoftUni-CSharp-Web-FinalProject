using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldRallyChampionship.Data.Models;
using WorldRallyChampionship.Services.Core;
using WorldRallyChampionship.Web.ViewModels.Driver;
using WorldRallyChampionship.Tests.Utils;
using WorldRallyChampionship.Data;
using Microsoft.EntityFrameworkCore;


namespace WorldRallyChampionship.Tests.Services
{
	[TestClass]
	public class DriverServiceTests
	{
		private ApplicationDbContext _ctx = default!;
		private DriverService _service = default!;

		[TestInitialize]
		public void Init()
		{
			_ctx = TestDb.Create();       
			_service = new DriverService(_ctx);
		}

		[TestCleanup]
		public void Cleanup() => _ctx.Dispose();

		[TestMethod]
		public async Task CreateAsync_Should_Add_Driver()
		{
			var model = new DriverFormModel
			{
				FirstName = "Elfyn",
				LastName = "Evans",
				Nationality = "Wales",
				DateOfBirth = new DateTime(1988, 12, 28),
				TeamId = 1
			};

			var id = await _service.CreateAsync(model);

			var d = await _ctx.Drivers.FindAsync(id);
			Assert.IsNotNull(d);
			Assert.AreEqual("Elfyn", d!.FirstName);
		}

		[TestMethod]
		public async Task GetAllAsync_Should_Return_ViewModels()
		{
			// seed вече има 3 драйвъра
			var list = (await _service.GetAllAsync()).ToList();
			Assert.IsTrue(list.Count >= 3);
			Assert.IsFalse(string.IsNullOrEmpty(list[0].FullName));
		}

		[TestMethod]
		public async Task GetByIdAsync_Should_Return_Details()
		{
			var d = new Driver
			{
				Id = 21,
				FirstName = "Kalle",
				LastName = "Rovanperä",
				Nationality = "Finland",
				DateOfBirth = new DateTime(2000, 10, 1),
				TeamId = 1
			};
			_ctx.Drivers.Add(d);
			await _ctx.SaveChangesAsync();

			var vm = await _service.GetByIdAsync(21);

			Assert.IsNotNull(vm);
			Assert.AreEqual("Kalle", vm!.FirstName);
			Assert.AreEqual("Toyota Gazoo Racing", vm.TeamName);
		}

		[TestMethod]
		public async Task UpdateAsync_Should_Modify_Entity()
		{
			var d = new Driver
			{
				Id = 31,
				FirstName = "Adrien",
				LastName = "Fourmaux",
				Nationality = "France",
				DateOfBirth = new DateTime(1995, 5, 3),
				TeamId = 2
			};
			_ctx.Drivers.Add(d);
			await _ctx.SaveChangesAsync();

			var model = new DriverFormModel
			{
				FirstName = "Adrien",
				LastName = "Fourmaux",
				Nationality = "France",
				DateOfBirth = new DateTime(1995, 5, 3),
				TeamId = 1
			};

			var ok = await _service.UpdateAsync(31, model);
			var updated = await _ctx.Drivers.FindAsync(31);

			Assert.IsTrue(ok);
			Assert.IsNotNull(updated);
			Assert.AreEqual(1, updated!.TeamId);
		}

		[TestMethod]
		public async Task DeleteAsync_Should_Remove_Entity()
		{
			_ctx.Drivers.Add(new Driver
			{
				Id = 41,
				FirstName = "Gregoire",
				LastName = "Munster",
				Nationality = "Luxembourg",
				DateOfBirth = new DateTime(1998, 3, 24),
				TeamId = 2
			});
			await _ctx.SaveChangesAsync();

			var ok = await _service.DeleteAsync(41);

			Assert.IsTrue(ok);
			Assert.AreEqual(0, _ctx.Drivers.Count(d => d.Id == 41));
		}
	}
}
