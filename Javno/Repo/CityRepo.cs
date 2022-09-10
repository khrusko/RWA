using Javno.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Javno.Repo
{
	public class CityRepo
	{
		private readonly string _connectionString;

		public CityRepo()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<City> GetCities()
		{
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetCities");

			var cityList = new List<Javno.Models.City>();
			cityList.Add(new Javno.Models.City { Id = 0, Name = "(Choose)" });
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var city = new Javno.Models.City();
				city.Id = Convert.ToInt32(row["ID"]);
				city.Guid = Guid.Parse(row["Guid"].ToString());
				city.Name = row["Name"].ToString();
				cityList.Add(city);
			}

			return cityList;
		}


	}
}