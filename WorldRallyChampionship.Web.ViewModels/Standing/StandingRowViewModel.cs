using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.Standing
{
	public class StandingRowViewModel
	{
		public int Position { get; set; }
		public string DriverName { get; set; } = null!;
		public string CoDriverName { get; set; } = null!;
		public string TeamName { get; set; } = null!;
		public string? CarModel { get; set; }
		public int? CarNumber { get; set; }
		public string TotalTime { get; set; } = null!;
		public string? DiffToLeader { get; set; }
		public int Points { get; set; }
		public int PowerStagePoints { get; set; }
	}
}
