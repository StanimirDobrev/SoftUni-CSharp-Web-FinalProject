using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.Team
{
	public class TeamDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Manufacturer { get; set; } = null!;

		public string? LogoUrl { get; set; }
		public IEnumerable<string> DriverNames { get; set; } = new List<string>();
	}
}
