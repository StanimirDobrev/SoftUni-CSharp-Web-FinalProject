namespace WorldRallyChampionship.Web.ViewModels.Driver
{
	public class DriverDetailsViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Nationality { get; set; } = null!;
		public DateTime DateOfBirth { get; set; }
		public string TeamName { get; set; } = null!;
	}

}


