using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class RallyEvent
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(100)]
		public string Country { get; set; } = null!;

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		[StringLength(50)]
		public string Surface { get; set; } = null!;

		[StringLength(1000)]
		public string? Description { get; set; }

		public ICollection<Result> Results { get; set; } = new List<Result>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
