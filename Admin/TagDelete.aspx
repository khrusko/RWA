<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TagDelete.aspx.cs" Inherits="Admin.TagDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h3>Jeste li sigurni da želite izbrisati sljedeći tag:</h3>
	<hr />
	<table>
		<tr>
			<td>
				<div class="form-group col-md-8">
					<label>Naziv taga (Hrvatski)</label>
					<asp:Label ID="lblTagNameHrv" runat="server" CssClass="form-control"></asp:Label>
				</div>
			</td>
			<td>
				<div class="form-group col-md-8">
					<label>Naziv taga (Engleski)</label>
					<asp:Label ID="lblTagNameEng" runat="server" CssClass="form-control"></asp:Label>
				</div>
			</td>
		</tr>

		<tr>
			<td>
				<div class="form-group col-md-8">
					<label>Tip taga (Hrvatski)</label>
					<asp:Label ID="lblTagTypeHrv" runat="server" CssClass="form-control"></asp:Label>
				</div>
			</td>
			<td>
				<div class="form-group col-md-8">
					<label>Tip taga (Engleski)</label>
					<asp:Label ID="lblTagTypeEng" runat="server" CssClass="form-control"></asp:Label>
				</div>

			</td>
		</tr>
	</table>





	<span class="col-md-6">
		<asp:LinkButton ID="lblDelete" runat="server" Text="Izbriši" CssClass="btn btn-danger" OnClick="lblDeleteConfirm_Click" />
		<asp:LinkButton ID="lblBack" runat="server" Text="Odustani" CssClass="btn btn-secondary" OnClick="lblBack_Click" />
	</span>
</asp:Content>
