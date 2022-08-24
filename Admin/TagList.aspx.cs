using Admin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	
	public partial class TagList : System.Web.UI.Page
	{
		private readonly TagRepository _tagRepository;

		public TagList()
		{
			_tagRepository = new TagRepository();
		}
			protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				gvTagList.DataSource =	_tagRepository.GetApartmentTagsWithOccurenceZero();
				gvTagList.DataBind();

				gvTagList1.DataSource = _tagRepository.GetApartmentTagsWithOccurencePos();
				gvTagList1.DataBind();
			}
		}

		protected void lbTagList_Click(object sender, EventArgs e)
		{
			Response.Redirect("TagAdd.aspx");
		}


	}
}