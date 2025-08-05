using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		// Additional properties can be added here if needed
		// For example, you might want to add a FullName property or a ProfilePictureUrl
		// public string FullName { get; set; } = null!;
		// public string? ProfilePictureUrl { get; set; }

		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
