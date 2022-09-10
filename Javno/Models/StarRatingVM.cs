using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class StarRatingVM
	{
		public string Question { get; set; }
		public int Rating { get; set; }
		public int MaxRating { get; set; } = 5;
	}
}