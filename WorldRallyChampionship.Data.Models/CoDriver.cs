using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldRallyChampionship.GCommon.ValidationConstants.CoDriver;

namespace WorldRallyChampionship.Data.Models
{
	public class CoDriver
	{
		[Key]
		public int Id { get; set; }


		[Required] 
		[StringLength(FirstNameMaxLength), MinLength(FirstNameMinLength)]
		public string FirstName { get; set; } = null!;


		[Required] 
		[StringLength(LastNameMaxLength), MinLength(LastNameMinLength)]
		public string LastName { get; set; } = null!;


		[Required] 
		[StringLength(NationalityMaxLength), MinLength(NationalityMinLength)]
		public string Nationality { get; set; } = null!;


		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }


		[ForeignKey(nameof(Team))]
		public int TeamId { get; set; }


		public Team Team { get; set; } = null!;


		public string? ImageUrl { get; set; }
	}
}
