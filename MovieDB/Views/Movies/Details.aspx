<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.Models.Movie>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Movie: <%= Html.Encode(Model.title) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
    <h2><%= Html.Encode(Model.title) %></h2>
    
    <p>
        <strong>Year:</strong>
        <%= Html.Encode(Model.year) %>
    </p>
    <p>
        <strong>Length:</strong>
        <%= Html.Encode(Model.length) %>&nbsp;minutes
    </p>
    <p>
        <strong>Genre:</strong>
        <%= Html.Encode(Model.Genre.genre_name) %>
    </p>
    <p>
        <strong>Rating:</strong>
        <%= (Model.Rating != null) ? Html.Encode(Model.Rating.rating_name) : "" %>
    </p>
    <p>
        <strong>Director:</strong>
        <%= (Model.Director != null) ? Html.Encode(Model.Director.FullName) : "" %>
    </p>
    <p>
        <strong>Location:</strong>
        <%= Html.Encode(Model.Location.location_name) %>
    </p>
    
    <p>
        <%=Html.ActionLink("Edit Movie", "Edit", new { id = Model.movie_id }) %>&nbsp;|&nbsp;
        <%=Html.ActionLink("Delete Movie", "Delete", new { id = Model.movie_id })%>&nbsp;|&nbsp;
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

