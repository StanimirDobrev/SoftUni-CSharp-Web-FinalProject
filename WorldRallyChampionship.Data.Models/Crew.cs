using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldRallyChampionship.GCommon.ValidationConstants.Crew;

namespace WorldRallyChampionship.Data.Models
{
	public class Crew
	{
		public int Id { get; set; }


		[Required] 
		public int DriverId { get; set; }


		[ForeignKey(nameof(DriverId))] 
		public Driver Driver { get; set; } = null!;

		[Required] 
		public int CoDriverId { get; set; }


		[ForeignKey(nameof(CoDriverId))] 
		public CoDriver CoDriver { get; set; } = null!;


		[Required] 
		public int TeamId { get; set; }


		[ForeignKey(nameof(TeamId))] 
		public Team Team { get; set; } = null!;


		[Required] 
		[MaxLength(CarModelMaxLength), MinLength(CarModelMinLength)] 
		public string CarModel { get; set; } = null!;


		public int? CarNumber { get; set; }


		[StringLength(CarImageUrlMaxLength)]
        public string? CarImageUrl { get; set; }
    }
}
