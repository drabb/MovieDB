<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MovieDB.Models.Genre>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Genres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Genres</h2>

    <table>
        <tr>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.genre_name) %>
            </td>
            <td>
                <%= Html.Encode(item.genre_desc) %>
            </td>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.genre_id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.genre_id })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

