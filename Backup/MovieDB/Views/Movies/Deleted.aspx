<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Deleted
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Movie Deleted</h2>
    
    <div>
        <p>The movie was successfully deleted.</p>
    </div>
    
    <div>
        <a href='/Movies'>Movies Listing</a>
    </div>

</asp:Content>
