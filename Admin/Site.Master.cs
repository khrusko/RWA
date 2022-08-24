using Admin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lbLogout_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("Logon.aspx", true);
		}

		//[WebMethod]
		//[ScriptMethod]
		//public static string Test()
		//{
		//	return "Test123";
		//}

		//[WebMethod]
		//[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		//public static List<Models.City> Test()
		//{
		//	var repo = new CityRepository();
		//	return repo.GetCities();
		//}
	}
}