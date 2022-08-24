using Admin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	public partial class TagDelete : System.Web.UI.Page
	{
		private readonly TagRepository _tagRepository;
		public TagDelete()
		{
			_tagRepository = new TagRepository();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string qryStrId = Request.QueryString["Id"];
				int? id = null;
				if (!string.IsNullOrEmpty(qryStrId))
				{
					id = int.Parse(qryStrId);
					var dbTag = _tagRepository.GetTag(id.Value);
					SetFormTag(dbTag);
				}
			}
		}

		protected void lblBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("TagList.aspx");
		}

		protected void lblDeleteConfirm_Click(object sender, EventArgs e)
		{
			string qryStrId = Request.QueryString["id"];
			var id = int.Parse(qryStrId);
			_tagRepository.DeleteTag(id);

			Response.Redirect("TagList.aspx");
		}

		private void SetFormTag(Models.CreateTag tag)
		{
			lblTagNameEng.Text = tag.NameEng;
			lblTagNameHrv.Text = tag.NameHrv;
			lblTagTypeHrv.Text = tag.TypeNameHrv;
			lblTagTypeEng.Text = tag.TypeNameEng;
		}

	}
}