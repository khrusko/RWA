<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h3>Lista svih registriranih korisnika</h3>

	<hr class="col-xs-12">

	<div class="container-md">
		<asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-condensed table-hover mb-0">
			<Columns>
				<asp:BoundField DataField="UserName" HeaderText="Ime i prezime" ItemStyle-Width="150px" />
				<asp:BoundField DataField="Email" HeaderText="E-mail" ItemStyle-Width="50px" />
				<asp:BoundField DataField="Address" HeaderText="Adresa" ItemStyle-Width="300px" />
				<asp:BoundField DataField="PhoneNumber" HeaderText="Broj mobitela" ItemStyle-Width="100px" />



			</Columns>
		</asp:GridView>
	</div>
</asp:Content>
