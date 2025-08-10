namespace WorldRallyChampionship.Web.ViewModels.Driver
{
	public class DriverDetailsViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string FullName => $"{FirstName} {LastName}";
		public string Nationality { get; set; } = null!;
		public DateTime DateOfBirth { get; set; }
		public string TeamName { get; set; } = null!;

		public string ImageUrl { get; set; } = "/img/placeholder.jpg";
	}

}


