using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class Driver
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string Nationality { get; set; } = null!;

		[Required]
		public DateTime DateOfBirth { get; set; }

		[ForeignKey(nameof(Team))]
		public int TeamId { get; set; }

		public Team Team { get; set; } = null!;

		public ICollection<Result> Results { get; set; } = new List<Result>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
