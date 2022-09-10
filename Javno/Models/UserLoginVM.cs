using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Javno.Models
{
	public class UserLoginVM
	{
		public int Id { get; set; }
		public Guid Guid { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[Display(Name ="Password")]
		public string PasswordHash { get; set; }
		public string SecurityStamp { get; set; }
		public string PhoneNumber { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public DateTime LockoutEndDateUtc { get; set; }
		public bool LockoutEnabled { get; set; }
		public int AccessFailedCount { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
	}
}