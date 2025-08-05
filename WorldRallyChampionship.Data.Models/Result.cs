using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class Result
	{
		public int Id { get; set; }

		[Required]
		public int RallyEventId { get; set; }

		public RallyEvent RallyEvent { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Driver))]
		public int DriverId { get; set; }

		public Driver Driver { get; set; } = null!;

		[Required]
		[Range(1, 99)]
		public int Position { get; set; }

		[Required]
		public TimeSpan Time { get; set; }

		[Required]
		[Range(0, 50)]
		public int Points { get; set; }
	}
}
