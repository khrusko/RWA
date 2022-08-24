<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="Admin.Error404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="d-flex align-items-center justify-content-center vh-100">
            <div class="text-center">
                <h1 class="display-1 fw-bold">404</h1>
                <p class="fs-3"> <span class="text-danger">Opps!</span> Stranica nije pronađena.</p>
                <p class="lead">
                    Tražena stranica ne postoji.
                  </p>
                <a href="ApartmentList.aspx" class="btn btn-primary">Početna</a>
            </div>
        </div>
</asp:Content>
