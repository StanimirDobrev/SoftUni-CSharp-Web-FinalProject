using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldRallyChampionship.GCommon.ValidationConstants.Crew;

namespace WorldRallyChampionship.Web.ViewModels.Crew
{
	public class CrewFormModel
	{
		[Required] 
		public int DriverId { get; set; }


		[Required] 
		public int CoDriverId { get; set; }


		[Required] 
		public int TeamId { get; set; }


		[Required]
		[StringLength(CarModelMaxLength),MinLength(CarModelMinLength)] 
		public string CarModel { get; set; } = null!;


		public int? CarNumber { get; set; }


		[StringLength(CarImageUrlMaxLength)] 
		public string? CarImageUrl { get; set; }


		public IEnumerable<OptionViewModel> Drivers { get; set; } = Enumerable.Empty<OptionViewModel>();
		public IEnumerable<OptionViewModel> Teams { get; set; } = Enumerable.Empty<OptionViewModel>();
	}
}
