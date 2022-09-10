using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class SearchResultVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? StarRating { get; set; } //Shown as stars
		public string CityName { get; set; }
		public int? BeachDistance { get; set; }
		public int? TotalRooms { get; set; }
		public int? MaxAdults { get; set; }
		public int? MaxChildren { get; set; }
		public decimal Price { get; set; }
		public string RepresentativePicturePath { get; set; } //Shown as picture
	}
}