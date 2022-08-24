using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Admin.Repositories
{
	public class ApartmentOwnerRepository
	{
  private readonly string _connectionString;

  public ApartmentOwnerRepository()
  {
   _connectionString = ConfigurationManager.ConnectionStrings["rwadb"].ConnectionString;
  }

  public List<Admin.Models.ApartmentOwner> GetApartmentOwners()
  {
   var ds = SqlHelper.ExecuteDataset(
       _connectionString,
       CommandType.StoredProcedure,
       "dbo.GetApartmentOwners");

   var ownerList = new List<Admin.Models.ApartmentOwner>();
   ownerList.Add(new Admin.Models.ApartmentOwner { Id = 0, Name = "(odabir vlasnika)" });
   foreach (DataRow row in ds.Tables[0].Rows)
   {
    var owner = new Admin.Models.ApartmentOwner();
    owner.Id = Convert.ToInt32(row["ID"]);
    owner.Name = row["Name"].ToString();
    ownerList.Add(owner);
   }

   return ownerList;
  }


  public List<Admin.Models.ApartmentOwner> GetApartmentOwnersRaw()
  {
   var ds = SqlHelper.ExecuteDataset(
       _connectionString,
       CommandType.StoredProcedure,
       "dbo.GetApartmentOwners");

   var ownerList = new List<Admin.Models.ApartmentOwner>();
   //ownerList.Add(new Admin.Models.ApartmentOwner { Id = 0, Name = "(odabir vlasnika)" });
   foreach (DataRow row in ds.Tables[0].Rows)
   {
    var owner = new Admin.Models.ApartmentOwner();
    owner.Id = Convert.ToInt32(row["ID"]);
    owner.Name = row["Name"].ToString();
    ownerList.Add(owner);
   }

   return ownerList;
  }
 }
}