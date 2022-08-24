<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TagAdd.aspx.cs" Inherits="Admin.TagAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="form-group col-md-12">
		<label>Naziv taga (Hrvatski)</label>
		<asp:RequiredFieldValidator ControlToValidate="tbTagNameHrv" Display="Static" ErrorMessage="Obvezno" runat="server" ID="RequiredFieldValidator3" ForeColor="Red" />

		<asp:TextBox ID="tbTagNameHrv" runat="server" CssClass="form-control"></asp:TextBox>
	</div>

	<div class="form-group col-md-12">
		<label>Naziv taga (Engleski)</label>
		<asp:TextBox ID="tbTagNameEng" runat="server" CssClass="form-control"></asp:TextBox>
	</div>

	<div class="form-group col-md-12">
		<label>Odabir vrste taga</label>
		<asp:DropDownList
			ID="ddlTagType"
			runat="server"
			CssClass="form-control"
			DataValueField="Id"
			DataTextField="NameHrv"
			AutoPostBack="true"
			OnSelectedIndexChanged="ddlTagType_SelectedIndexChanged">
		</asp:DropDownList>
	</div>

	<span class="col-md-6">
		<asp:LinkButton ID="lblSave" runat="server" Text="Spremi" CssClass="btn btn-primary" OnClick="lblSave_Click" />
		<asp:LinkButton ID="lblBack" runat="server" Text="Odustani" CssClass="btn btn-secondary" OnClick="lblBack_Click" />
	</span>
</asp:Content>
