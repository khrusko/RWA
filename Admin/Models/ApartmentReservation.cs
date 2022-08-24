using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
	public class ApartmentReservation
	{
		public int Id { get; set; }
		public Guid Guid { get; set; }
		public DateTime CreatedAt { get; set; }
		public int ApartmentId { get; set; }
		public string Details { get; set; }
		public int? UserID { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public string UserPhone { get; set; }
		public string UserAddress { get; set; }
	}
}