using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class ApartmentReviewVM
	{
		public int Stars { get; set; }
		public int ApartmentId { get; set; }
		public string Details { get; set; }
		public int UserId { get; set; }
	}
}