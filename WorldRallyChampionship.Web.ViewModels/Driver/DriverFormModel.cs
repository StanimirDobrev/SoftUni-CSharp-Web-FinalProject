using System.ComponentModel.DataAnnotations;

namespace WorldRallyChampionship.Web.ViewModels.Driver
{
	public class DriverFormModel
	{
        public int Id { get; set; }

        [Required]
		public string FirstName { get; set; } = null!;

		[Required]
		public string LastName { get; set; } = null!;

		[Required]
		public string Nationality { get; set; } = null!;

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public int TeamId { get; set; }

		public string? ImageUrl { get; set; } = null!;
	}
}
