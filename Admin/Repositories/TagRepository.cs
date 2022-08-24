using Admin.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Admin.Repositories
{
	public class TagRepository
	{
		private readonly string _connectionString;

		public TagRepository()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<Admin.Models.Tag> GetTags()
		{
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetTags");

			var tagList = new List<Admin.Models.Tag>();
			//tagList.Add(new Admin.Models.Tag { Id = 0, Name = "(odabir taga)" });
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var tag = new Admin.Models.Tag();
				tag.Id = Convert.ToInt32(row["ID"]);
				tag.Name = row["Name"].ToString();
				tagList.Add(tag);
			}

			return tagList;
		}


		public CreateTag GetTag(int id)
		{

			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@id", id));

			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetTag",
							commandParameters.ToArray());


			var tag = new CreateTag();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				tag.Id = Convert.ToInt32(row["Id"]);
				tag.NameHrv = row["TagNameHrv"].ToString();
				tag.NameEng = row["TagNameEng"].ToString();
				tag.TypeNameHrv = row["TagTypeNameHrv"].ToString();
				tag.TypeNameEng = row["TagTypeNameEng"].ToString();
			}

			return tag;
		}


		public List<Admin.Models.Tag> GetApartmentTagsWithOccurencePos()
		{
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetApartmentTagsWithOccurence");

			var tagList = new List<Admin.Models.Tag>();
			//tagList.Add(new Admin.Models.Tag { Id = 0, Name = "(odabir taga)" });
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var tag = new Admin.Models.Tag();

				tag.Id = Convert.ToInt32(row["counted"]);
				tag.Name = row["Name"].ToString();
				//Id serves the purpose of counting the occurence of each tag since ID is not necessary in this function
				if (tag.Id != 0)
				{
					tagList.Add(tag);
				}
			}

			return tagList;
		}


		public List<Admin.Models.Tag> GetApartmentTagsWithOccurenceZero()
		{
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetApartmentTagsWithOccurence");

			var tagList = new List<Admin.Models.Tag>();
			//tagList.Add(new Admin.Models.Tag { Id = 0, Name = "(odabir taga)" });
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var tag = new Admin.Models.Tag();

				tag.Counted = Convert.ToInt32(row["counted"]);
				tag.Name = row["Name"].ToString();
				tag.Id = Convert.ToInt32(row["Id"]);
				if (tag.Counted == 0)
				{
					tagList.Add(tag);
				}
			}

			return tagList;
		}

		public void CreateTag(Admin.Models.CreateTag tag)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@guid", tag.Guid));
			commandParameters.Add(new SqlParameter("@typeId", tag.TypeId));
			commandParameters.Add(new SqlParameter("@name", tag.NameHrv));
			commandParameters.Add(new SqlParameter("@nameEng", tag.NameEng));
			if (tag.NameHrv !="")
			{
				SqlHelper.ExecuteNonQuery(
								_connectionString,
								CommandType.StoredProcedure,
								"dbo.CreateTag",
								commandParameters.ToArray());
			}
		}

		public void DeleteTag(int id)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@id", id));

			SqlHelper.ExecuteNonQuery(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.DeleteTag",
							commandParameters.ToArray());
		}


	}
}