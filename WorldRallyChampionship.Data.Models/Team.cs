using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldRallyChampionship.GCommon.ValidationConstants.Team;

namespace WorldRallyChampionship.Data.Models
{
	public class Team
	{
		public int Id { get; set; }

		[Required]
		[StringLength(TeamNameMaxLength),MinLength(TeamNameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(ManufacturerMaxLength), MinLength(ManufacturerMinLength)]
		public string Manufacturer { get; set; } = null!;

		public string? LogoUrl { get; set; }

		public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
	}
}
