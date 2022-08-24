using Admin.Repositories;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
	public partial class TagAdd : System.Web.UI.Page
	{
		private readonly TagRepository _tagRepository;
		private readonly TagTypeRepository _tagTypeRepository;

		public TagAdd()
		{
			_tagRepository = new TagRepository();
			_tagTypeRepository = new TagTypeRepository();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				RebindTagTypes();
				GetSelectedTag();
			}
		}

		protected void ddlTagType_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void lblSave_Click(object sender, EventArgs e)
		{
			var createTag = GetCreateTag();
			_tagRepository.CreateTag(createTag);
			Response.Redirect($"TagList.aspx");
		}

		protected void lblBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("TagList.aspx");
		}


		private Models.Tag GetSelectedTag()
		{
			var selectedValue = ddlTagType.SelectedItem.Value;
			var newTag = new Models.Tag
			{
				Id = int.Parse(ddlTagType.SelectedItem.Value),
				Name = ddlTagType.SelectedItem.Text
			};
			return newTag;
		}

		private void RebindTagTypes()
		{
			ddlTagType.DataSource = _tagTypeRepository.GetTagTypes();
			ddlTagType.DataBind();
		}



		private Models.CreateTag GetCreateTag()
		{
			int typeId = int.Parse(ddlTagType.SelectedValue);


			return
							new Models.CreateTag
							{
								// Id kreira baza
								Guid = Guid.NewGuid(),
								// CreatedAt kreira baza
								TypeId = typeId,
								NameHrv = tbTagNameHrv.Text,
								NameEng = tbTagNameEng.Text,
							};
		}


	}
}