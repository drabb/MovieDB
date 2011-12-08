<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.Models.Movie>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete: <%= Html.Encode(Model.title) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Movie?</h2>
    
    <div>
        <p>Please confirm that you wish to delete <strong>&quot;<%= Html.Encode(Model.title) %>&quot;</strong></p>
    </div>
    
    <% using (Html.BeginForm()) { %>
        <input name='confirmButton' type='submit' value='Delete' />
    <% } %>
</asp:Content>
