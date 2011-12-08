<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.ViewModels.MovieFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Movie: <%= Html.Encode(Model.Movie.title)%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>
    
    <% Html.RenderPartial("MovieForm"); %>
        
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

