using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class ContactReservationVM
	{
		[Display(Name ="First name")]
		[Required(ErrorMessage ="First name is required")]
		public string FirstName { get; set; }
		[Display(Name = "Last name")]
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }
		[Display(Name = "E-mail")]
		[Required(ErrorMessage = "Email name is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Display(Name = "Phone")]
		[Required(ErrorMessage = "Phone is required")]
		public string PhoneMobile { get; set; }
		[Display(Name = "Number of adults")]
		[Required(ErrorMessage = "Number of adults is required")]
		public int NumberOfAdults { get; set; }
		[Display(Name = "Number of children")]
		[Required(ErrorMessage = "Number of children is required")]
		public int NumberOfChildren { get; set; }
	}
}