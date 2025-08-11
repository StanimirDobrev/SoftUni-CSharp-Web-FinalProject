using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldRallyChampionship.GCommon
{
	public class ValidationConstants
	{
		public class Driver
		{
			public const int FirstNameMaxLength = 50;
			public const int FirstNameMinLength = 2;

			public const int LastNameMaxLength = 50;
			public const int LastNameMinLength = 2;
			
			public const int NationalityMaxLength = 50;
			public const int NationalityMinLength = 2;

		}

		public class Comment
		{
			public const int ContentMaxLength = 1000;
			public const int ContentMinLength = 5;
		}

		public class Team
		{
			public const int TeamNameMaxLength = 100;
			public const int TeamNameMinLength = 3;

			public const int ManufacturerMaxLength = 100;
			public const int ManufacturerMinLength = 5;
		}
	}
}
