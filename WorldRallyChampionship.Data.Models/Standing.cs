using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class Standing
	{
		[Key]
		public int Id { get; set; }


		[ForeignKey(nameof(RallyEvent))]
		public int RallyEventId { get; set; }


		public RallyEvent RallyEvent { get; set; } = null!;


		[ForeignKey(nameof(Crew))]
		public int CrewId { get; set; }


		public Crew Crew { get; set; } = null!;


		[Range(1, 200)]
		public int Position { get; set; }


		[Required, MaxLength(32)]
		public string TotalTime { get; set; } = null!;



		[MaxLength(32)]
		public string? DiffToLeader { get; set; }



		[Range(0, 30)]
		public int Points { get; set; }


		[Range(0, 5)]
		public int PowerStagePoints { get; set; }
	}
}
