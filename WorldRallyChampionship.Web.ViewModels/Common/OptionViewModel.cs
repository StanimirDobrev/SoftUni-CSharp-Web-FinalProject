using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.Web.ViewModels.Common
{
	public class OptionViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Value { get; set; }
		public string Text { get; set; } = null!;
	}
}
