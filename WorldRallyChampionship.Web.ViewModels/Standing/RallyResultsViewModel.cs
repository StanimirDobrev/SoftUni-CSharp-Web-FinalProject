using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.Standing
{
	public class RallyResultsViewModel
	{
		public int RallyId { get; set; }
		public string RallyName { get; set; } = null!;
		public string Country { get; set; } = null!;
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Surface { get; set; } = null!;
		public string? ImageUrl { get; set; }

		public IList<StandingRowViewModel> Rows { get; set; } = new List<StandingRowViewModel>();
	}
}
