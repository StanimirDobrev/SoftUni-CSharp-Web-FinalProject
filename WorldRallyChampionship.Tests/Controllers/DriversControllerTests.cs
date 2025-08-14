using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldRallyChampionship.Services.Core.Contracts;
using WorldRallyChampionship.Web.Controllers;
using WorldRallyChampionship.Web.ViewModels.Driver;

namespace WorldRallyChampionship.Tests.Controllers
{
	[TestClass]
	public class DriversControllerTests
	{
		[TestMethod]
		public async Task Index_Returns_View_With_Model()
		{
			var driverMock = new Mock<IDriverService>();
			driverMock.Setup(s => s.GetAllAsync())
				.ReturnsAsync(new List<DriverViewModel>
				{
			new DriverViewModel { Id = 1, FullName = "Elfyn Evans", Nationality = "Wales", TeamName = "Toyota" }
				});

			var teamMock = new Mock<ITeamService>();

			var controller = new DriverController(driverMock.Object, teamMock.Object);

			var result = await controller.Index();

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ViewResult));

			var model = (IEnumerable<DriverViewModel>)((ViewResult)result).Model!;
			Assert.AreEqual(1, model.Count());
		}
	}
}
