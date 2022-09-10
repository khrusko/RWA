using Javno.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Web;


namespace Javno.Repo
{
	public class ApartmentRepo
	{

		private readonly string _connectionString;
		public ApartmentRepo()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
		}

		public List<SearchResultVM> LoadAllApartments()
		{
			var ds = SqlHelper.ExecuteDataset(
										_connectionString,
										CommandType.StoredProcedure,
										"dbo.GetPublicApartments");

			var resList = new List<SearchResultVM>();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var ap = new Javno.Models.SearchResultVM();

				ap.Id = Convert.ToInt32(row["Id"]);
				ap.Name = row["Name"].ToString();
				ap.StarRating = row["StarRating"] != DBNull.Value ? (int?)Convert.ToInt32(row["StarRating"]) : null;
				ap.CityName = row["CityName"].ToString();
				ap.BeachDistance =	row["BeachDistance"] != DBNull.Value ?	(int?)Convert.ToInt32(row["BeachDistance"]) :	null;
				ap.TotalRooms = row["TotalRooms"] != DBNull.Value ? (int?)Convert.ToInt32(row["TotalRooms"]) : null;
				ap.MaxAdults = row["MaxAdults"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxAdults"]) : null;
				ap.MaxChildren = row["MaxChildren"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxChildren"]) : null;
				ap.Price = decimal.Round(Convert.ToDecimal(row["Price"]),2);
				
				ap.RepresentativePicturePath = GetPublicApartmentRepresentativePicture(ap.Id).Path;
				resList.Add(ap);
			}

			return resList;
		}

		public List<SearchResultVM> Search(
						int? rooms,
						int? adults,
						int? children,
						int? destination,
						int? order)
		{
			var commandParameters = new List<SqlParameter>();
			if (rooms.HasValue && rooms.Value >= 0)
			commandParameters.Add(new SqlParameter("@rooms", rooms));
			if (adults.HasValue && adults.Value >= 0)
				commandParameters.Add(new SqlParameter("@adults", adults));
			if (children.HasValue && children.Value >= 0)
				commandParameters.Add(new SqlParameter("@children", children));

			if (destination.HasValue && destination.Value > 0)
				commandParameters.Add(new SqlParameter("@destination", destination));
			commandParameters.Add(new SqlParameter("@order", order));

			var ds = SqlHelper.ExecuteDataset(
										_connectionString,
										CommandType.StoredProcedure,
										"dbo.SearchApartments",
										commandParameters.ToArray());

			var resList = new List<SearchResultVM>();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				var ap = new Javno.Models.SearchResultVM();

				ap.Id = Convert.ToInt32(row["Id"]);
				ap.Name = row["Name"].ToString();
				ap.StarRating = row["StarRating"] != DBNull.Value ? (int?)Convert.ToInt32(row["StarRating"]) : null;
				ap.CityName = row["CityName"].ToString();
				ap.BeachDistance = row["BeachDistance"] != DBNull.Value ? (int?)Convert.ToInt32(row["BeachDistance"]) : null;
				ap.TotalRooms = row["TotalRooms"] != DBNull.Value ? (int?)Convert.ToInt32(row["TotalRooms"]) : null;
				ap.MaxAdults = row["MaxAdults"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxAdults"]) : null;
				ap.MaxChildren = row["MaxChildren"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxChildren"]) : null;
				ap.Price = decimal.Round(Convert.ToDecimal(row["Price"]), 2);
				ap.RepresentativePicturePath = GetPublicApartmentRepresentativePicture(ap.Id).Path;

				resList.Add(ap);
			}

			return resList;
		}

		public Javno.Models.ApartmentDetails GetPublicApartmentDetails(int id)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@id", id));

			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetPublicApartment",
							commandParameters.ToArray());

			var row = ds.Tables[0].Rows[0];
			var ap = new Javno.Models.ApartmentDetails();
			ap.Id = Convert.ToInt32(row["Id"]);
			ap.Name = row["Name"].ToString();
			ap.StarRating = row["StarRating"] != DBNull.Value ? (int?)Convert.ToInt32(row["StarRating"]) : null;
			ap.CityName = row["CityName"].ToString();
			ap.BeachDistance = row["BeachDistance"] != DBNull.Value ? (int?)Convert.ToInt32(row["BeachDistance"]) : null;
			ap.TotalRooms = row["TotalRooms"] != DBNull.Value ? (int?)Convert.ToInt32(row["TotalRooms"]) : null;
			ap.MaxAdults = row["MaxAdults"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxAdults"]) : null;
			ap.MaxChildren = row["MaxChildren"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaxChildren"]) : null;
			ap.Price = decimal.Round(Convert.ToDecimal(row["Price"]), 2);
			ap.RepresentativePicture = GetPublicApartmentRepresentativePicture(ap.Id);
			return ap;
		}

		public List<string> GetPublicApartmentTags(int apartmentId)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@apartmentId", apartmentId));
			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetPublicApartmentTags",
							commandParameters.ToArray());
			var tags = new List<String>();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				tags.Add(row["Name"].ToString());
			}
			return tags;
		}

		public ApartmentPicture GetPublicApartmentRepresentativePicture(int apartmentId)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@apartmentId", apartmentId));

			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetPublicApartmentPictures",
							commandParameters.ToArray());

			foreach (DataRow row in ds.Tables[0].Rows)
			{
				if (bool.Parse(row["IsRepresentative"].ToString()))
				{
					var pic = new Models.ApartmentPicture
					{
						Id = Convert.ToInt32(row["Id"]),
						Path = row["Path"].ToString(),
						Name = row["Name"].ToString(),
						IsRepresentative = bool.Parse(row["IsRepresentative"].ToString())
					};
					return pic;
				}
			}
			var tpic = new Models.ApartmentPicture
			{
				Path = "DefaultImage.jpg",
				Name = "DefaultImage",
				IsRepresentative = true
			};
			return tpic;
		}

		public List<ApartmentPicture> GetPublicApartmentPicturesWithoutRepresentative(int apartmentId)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@apartmentId", apartmentId));

			var ds = SqlHelper.ExecuteDataset(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.GetPublicApartmentPictures",
							commandParameters.ToArray());

			var pics = new List<Javno.Models.ApartmentPicture>();
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				if (bool.Parse(row["IsRepresentative"].ToString())){ }

				pics.Add(new Models.ApartmentPicture
				{
					Id = Convert.ToInt32(row["Id"]),
					Path = row["Path"].ToString(),
					Name = row["Name"].ToString(),
					IsRepresentative = bool.Parse(row["IsRepresentative"].ToString())
				});
			}

			return pics;
		}

		public void CreateReservation (ApartmentDetails model)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@ApartmentId", model.Id));
			commandParameters.Add(new SqlParameter("@Details", model.ContactDetails));
			commandParameters.Add(new SqlParameter("@UserId", 0));
			commandParameters.Add(new SqlParameter("@UserName", model.ContactFirstName));
			commandParameters.Add(new SqlParameter("@UserEmail", model.ContactEmail));
			commandParameters.Add(new SqlParameter("@UserAddress", model.ContactAddress));
			commandParameters.Add(new SqlParameter("@UserPhone", model.ContactPhoneMobile));

			var ds = SqlHelper.ExecuteNonQuery(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.CreateReservation",
							commandParameters.ToArray());
		}

		public void CreateReview(ApartmentReviewVM model)
		{
			var commandParameters = new List<SqlParameter>();
			commandParameters.Add(new SqlParameter("@ApartmentId", model.ApartmentId));
			commandParameters.Add(new SqlParameter("@Details", model.Details));
			commandParameters.Add(new SqlParameter("@UserId", model.UserId));
			commandParameters.Add(new SqlParameter("@Stars", model.Stars));


			var ds = SqlHelper.ExecuteNonQuery(
							_connectionString,
							CommandType.StoredProcedure,
							"dbo.CreateApartmentReview",
							commandParameters.ToArray());
		}
	}
}