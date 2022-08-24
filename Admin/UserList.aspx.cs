using Admin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	public partial class UserList : System.Web.UI.Page
	{
		private readonly UserRepository _userRepository;
		public UserList()
		{
			_userRepository = new UserRepository();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				gvUserList.DataSource = _userRepository.GetUsers();
				gvUserList.DataBind();

			}
		}

	}
}