using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class SearchVM
	{
		[Display(Name ="Filter by the number of rooms")]
		public int FilterRooms { get; set; }
		[Display(Name = "Filter by the number of adults")]
		public int FilterAdults { get; set; }
		[Display(Name = "Filter by the number of children")]
		public int FilterChildren { get; set; }
		[Display(Name = "Filter by city")]
		public int FilterCity { get; set; }
		public List<City> CityList { get; set; }
		public List<Order> OrderList { get; set; }
		[Display(Name = "Order by")]
		public int Order { get; set; }
		public List<SearchResultVM> SearchResult { get; set; }
	}
}