using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorldRallyChampionship.GCommon.ValidationConstants.News;

namespace WorldRallyChampionship.Data.Models
{
	public class News
	{
		public int Id { get; set; }


		[Required] 
		[MaxLength(NewsTitleMaxLength), MinLength(NewsTitleMinLength)]
		public string Title { get; set; } = null!;


		[Required]
		[MaxLength(NewsSummaryMaxLength), MinLength(NewsSummaryMinLength)]
		public string Summary { get; set; } = null!;


		[Required]                       
		public string Content { get; set; } = null!;


		[MaxLength(ImageUrlMaxLength)]
		public string? ImageUrl { get; set; }   


		[MaxLength(SourceUrlMaxLength)]
		public string? SourceUrl { get; set; }  


		[MaxLength(AuthorMaxLength), MinLength(AuthorMinLength)]
		public string? Author { get; set; }


		public DateTime PublishedOn { get; set; } = DateTime.UtcNow;


		public bool IsFeatured { get; set; } = false;
	}
}
