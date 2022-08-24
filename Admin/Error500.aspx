<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error500.aspx.cs" Inherits="Admin.Error500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="d-flex align-items-center justify-content-center vh-100">
            <div class="text-center">
                <h1 class="display-1 fw-bold">500</h1>
                <p class="fs-3"> <span class="text-danger">Opps!</span> Interna serverska greška.</p>
                <p class="lead">
                    Nešto je pošlo po krivu.
                  </p>
                <a href="ApartmentList.aspx" class="btn btn-primary">Početna</a>
            </div>
        </div>
</asp:Content>
