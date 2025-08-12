using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.Crew
{
	public class CrewViewModel
	{
		public int Id { get; set; }
		public string DriverName { get; set; } = null!;
		public string DriverImageUrl { get; set; } = "/img/placeholder.jpg";
		public string CoDriverName { get; set; } = null!;
		public string CoDriverImageUrl { get; set; } = "/img/placeholder.jpg";
		public string TeamName { get; set; } = null!;
		public string? CarModel { get; set; }
		public int? CarNumber { get; set; }
		public string? CarImageUrl { get; set; }
		public int TeamId { get; set; }
		public int DriverId { get; set; }
		public int CoDriverId { get; set; }
	}
}
