
using Javno.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Javno.Repo
{
	public class OrderRepo
	{
		private readonly string _connectionString;

		public OrderRepo()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<Order> GetOrders()
  {
   return new List<Models.Order>
              {
                  new Models.Order { Id = 0, Name = "Default" },
                  new Models.Order { Id = 1, Name = "Number of rooms" },
                  new Models.Order { Id = 2, Name = "Number of adults" },
                  new Models.Order { Id = 3, Name = "Number of children" },
                  new Models.Order { Id = 4, Name = "Price" }
              };
  }



 }
}