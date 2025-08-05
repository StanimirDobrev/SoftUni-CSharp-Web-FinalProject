using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class Comment
	{
		public int Id { get; set; }

		[Required]
		[StringLength(1000)]
		public string Content { get; set; } = null!;

		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		// Optional link to RallyEvent
		public int? RallyEventId { get; set; }
		public RallyEvent? RallyEvent { get; set; }

		// Optional link to Driver
		public int? DriverId { get; set; }
		public Driver? Driver { get; set; }

		// Required link to ApplicationUser
		[Required]
		public string UserId { get; set; } = null!;
		public ApplicationUser User { get; set; } = null!;
	}
}
