using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.News
{
	public class NewsListItemViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Summary { get; set; } = null!;

		public string? ImageUrl { get; set; }

		public DateTime PublishedOn { get; set; }
	}
}
