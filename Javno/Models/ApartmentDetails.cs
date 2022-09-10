using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class ApartmentDetails
	{
		public int Id { get; set; }
  public string Name { get; set; }
  public string CityName { get; set; }
  public int? BeachDistance { get; set; }
  public int? TotalRooms { get; set; }
  public int? MaxAdults { get; set; }
  public int? MaxChildren { get; set; }
  public string OwnerName { get; set; }
  public decimal Price { get; set; }
		public List<string> Tags { get; set; }
		public int? StarRating { get; set; }
		[Required(ErrorMessage = "Full name is required")]
		[Display(Name = "Full name")]
		public string ContactFirstName { get; set; }
		[Required(ErrorMessage = "Email is required")]
		[Display(Name = "E-mail")]
		public string ContactEmail { get; set; }
		[Required(ErrorMessage = "Phone is required")]
		[Display(Name = "Phone")]
		public string ContactPhoneMobile { get; set; }
		[Required(ErrorMessage = "Details are required")]
		[Display(Name = "Details")]
		public string ContactDetails { get; set; }
		[Required(ErrorMessage = "Address is required")]
		[Display(Name = "Address")]
		public string ContactAddress { get; set; }
		[Required(ErrorMessage = "Number of adults is required")]
		[Display(Name = "Number of adults")]
		public int ContactNumberOfAdults { get; set; }
		[Required(ErrorMessage = "Number of children is required")]
		[Display(Name = "Number of children")]
		public int ContactNumberOfChildren { get; set; }
		[Display(Name = "Date from")]
		[Required(ErrorMessage = "Date from is required")]
		public DateTime ContactDateFrom { get; set; }
		[Required(ErrorMessage = "Date to is required")]
		[Display(Name = "Date to")]
		public DateTime ContactDateTo { get; set; }
		public List<ApartmentPicture> Pictures { get; set; }
		public ApartmentPicture RepresentativePicture { get; set; }
		public int UserId { get; set; }
		[Required(ErrorMessage = "Stars are required")]
		[Display(Name = "Stars")]
		public int Stars { get; set; }
	}
}