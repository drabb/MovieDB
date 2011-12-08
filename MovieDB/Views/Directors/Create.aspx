<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.Models.Director>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add a Director
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add a Director</h2>
    
    <% Html.RenderPartial("DirectorForm"); %>
    
    <div>
        <%=Html.ActionLink("Back to Directors", "Index") %>
    </div>

</asp:Content>

