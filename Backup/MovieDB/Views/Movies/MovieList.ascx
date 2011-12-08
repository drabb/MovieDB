<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MovieDB.Helpers.PaginatedList<MovieDB.Models.Movie>>" %>
<%@ Import Namespace='MovieDB.Helpers' %>

<table style='margin-top:8px;'>
    <tr>
        <th style='width:425px;'>Title</th>
        <th>Genre</th>
        <th>Rating</th>
        <th>Year</th>
        <th>Length</th>
        <th>Location</th>
        <th><!-- edit --></th>
        <th><!-- delete --></th>
    </tr>

<% foreach (var movie in Model) { %>

    <tr>
        <td><%= Html.ActionLink(movie.title, "Details", new { id = movie.movie_id }) %></td>
        <td><%= Html.Encode(movie.Genre.genre_name) %></td>
        <td align='center'><%= (movie.Rating != null) ? Html.Encode(movie.Rating.rating_name) : "" %></td>
        <td><%= Html.Encode(movie.year) %></td>
        <td><%= Html.Encode(movie.length) %>&nbsp;mins</td>
        <td><%= Html.Encode(movie.Location.location_name) %></td>
        <td><%= Html.ActionLink("Edit", "Edit", new { id=movie.movie_id }) %></td>
        <td><%= Html.ActionLink("[x]", "Delete", new { id = movie.movie_id })%></td>
    </tr>

<% } %>

    <%--<tr>
        <td>
            <% if (Model.HasPreviousPage) { %>
                <%= Html.RouteLink("<--", "MoviesListing", new { page = Model.PageIndex - 1 }) %>
            <% } %>
        </td>
        <td colspan='5'>
            
        </td>
        <td>
            <% if (Model.HasNextPage) { %>
                <%= Html.RouteLink("-->", "MoviesListing", new { page = Model.PageIndex + 1 })%>
            <% } %>
        </td>
    </tr>--%>
</table>

<%= Html.Pager(Model.PageIndex, Model.TotalPages) %>
