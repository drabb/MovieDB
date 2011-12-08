<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.Models.Genre>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Genre
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Genre</h2>
    
    <% Html.RenderPartial("GenreForm"); %>

    <div>
        <%=Html.ActionLink("Back to Genres", "Index") %>
    </div>

</asp:Content>

