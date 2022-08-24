<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TagList.aspx.cs" Inherits="Admin.TagList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h3>Lista svih tagova</h3>
			<div>
		<asp:LinkButton ID="lbTagList" runat="server" Text="Dodaj Tag" CssClass="btn btn-primary" OnClick="lbTagList_Click" />
	</div>
	<hr class="col-xs-12">

	<div class="container-md">
		<asp:GridView ID="gvTagList" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-condensed table-hover mb-0">
		<Columns>
			<asp:BoundField DataField="Name" HeaderText="Tag" ItemStyle-Width="300px" />
			<asp:BoundField DataField="Counted" HeaderText="Broj pojavljivanja"  ItemStyle-Width="100px"/>

				<asp:TemplateField HeaderText="Administracija" ItemStyle-Width="100px">
				<ItemTemplate>
					<asp:HyperLink ID="hlDelete" runat="server" CssClass="btn btn-danger" Text="Izbriši" NavigateUrl='<%# Eval("Id", "TagDelete.aspx?Id={0}") %>'></asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateField>

			</Columns>
			</asp:GridView>
		</div>
		<div class="container-md">
			<asp:GridView ID="gvTagList1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-condensed table-hover mt-0" ShowHeader="false">
		<Columns>
			<asp:BoundField DataField="Name" HeaderText="Naziv" ItemStyle-Width="235px" />
			<asp:BoundField DataField="Id" HeaderText="Broj pojavljivanja" ItemStyle-Width="94px" />

							<asp:TemplateField HeaderText="Administracija" ItemStyle-Width="105px">
				<ItemTemplate>
					<button class="btn btn-secondary" disabled>Izbriši</button>
				</ItemTemplate>
			</asp:TemplateField>
			</Columns>
			</asp:GridView>
			</div>
</asp:Content>
