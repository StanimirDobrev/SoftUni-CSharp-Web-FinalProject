using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.RallyEvent
{
	public class RallyEventDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Country { get; set; } = null!;

		public string Surface { get; set; } = null!;

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string? Description { get; set; }

		public string? ImageUrl { get; set; }
	}
}
