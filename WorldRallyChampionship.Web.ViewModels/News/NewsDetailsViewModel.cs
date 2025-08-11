using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.News
{
	public class NewsDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Content { get; set; } = null!;

		public string? ImageUrl { get; set; }

		public string? Author { get; set; }

		public DateTime PublishedOn { get; set; }

		public string? SourceUrl { get; set; }
	}
}
