namespace WorldRallyChampionship.Web.ViewModels.Driver
{
	public class DriverViewModel
	{
		public int Id { get; set; }
		public string FullName { get; set; } = null!;
		public string Nationality { get; set; } = null!;
		public string TeamName { get; set; } = null!;

		public string? ImageUrl { get; set; }
	}
}
