using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
	public class CreateTag
	{
		public int Id { get; set; }
		public Guid Guid { get; set; }
		public int TypeId { get; set; }
		public string NameHrv { get; set; }
		public string NameEng { get; set; }

		public string TypeNameHrv { get; set; }
		public string TypeNameEng { get; set; }
	}
}