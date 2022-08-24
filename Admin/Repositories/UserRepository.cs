using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Admin.Repositories
{
	public class UserRepository
	{
		private readonly string _connectionString;
		public UserRepository()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<Admin.Models.User> GetUsers()
		{

						var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetUsers");

			var userList = new List<Admin.Models.User>();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var user = new Admin.Models.User();
				user.UserName = row["UserName"].ToString();
				user.Email = row["Email"].ToString();
				user.Address = row["Address"].ToString();
				user.PhoneNumber = row["PhoneNumber"].ToString();
				userList.Add(user);
			}

			return userList;
		
		}
	}
}