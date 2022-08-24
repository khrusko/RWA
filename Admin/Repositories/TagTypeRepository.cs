using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Admin.Repositories
{
	public class TagTypeRepository
	{
		private readonly string _connectionString;

		public TagTypeRepository()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<Admin.Models.TagType> GetTagTypes()
		{
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetTagTypes");

			var tagList = new List<Admin.Models.TagType>();
			//tagList.Add(new Admin.Models.Tag { Id = 0, Name = "(odabir taga)" });
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var tag = new Admin.Models.TagType();
				tag.Id = Convert.ToInt32(row["ID"]);
				tag.NameHrv = row["Name"].ToString();
				tag.NameEng = row["NameEng"].ToString();
				tagList.Add(tag);
			}

			return tagList;
		}

	}
}