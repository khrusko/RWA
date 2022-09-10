using Javno.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Javno.Repo
{
	public class UserRepo
	{
		private readonly string _connectionString;
		public UserRepo()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public void CreateUser(User model)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@Email", model.Email));
			commandParameters.Add(new SqlParameter("@PasswordHash", model.PasswordHash));
			commandParameters.Add(new SqlParameter("@PhoneNumber", model.PhoneNumber));
			commandParameters.Add(new SqlParameter("@UserName", model.UserName));
			commandParameters.Add(new SqlParameter("@Address", model.Address));

			var ds = SqlHelper.ExecuteNonQuery(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.CreateUser",
							commandParameters.ToArray());
		}

		public UserLoginVM AuthUser(UserLoginVM model)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@Email", model.Email));
			commandParameters.Add(new SqlParameter("@PasswordHash", model.PasswordHash));

			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.AuthUser",
							commandParameters.ToArray());


			if (ds.Tables[0].Rows.Count == 0)
				return null;

			var row = ds.Tables[0].Rows[0];
			return new UserLoginVM
			{
				Email = row["Email"].ToString(),
				PhoneNumber = row["PhoneNumber"].ToString(),
				UserName = row["UserName"].ToString(),
				Address = row["Address"].ToString(),
				Id = int.Parse(row["Id"].ToString())
			};
		}


	}
}