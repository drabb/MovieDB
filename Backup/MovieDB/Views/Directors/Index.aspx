<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MovieDB.Models.Director>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Directors
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Directors</h2>

    <table>
<%--        <tr>
            <th>
                Name
            </th>
            <th></th>
        </tr>--%>
        <tr>

    <% int i = 0; foreach (var item in Model) { i++;  %>
        
            <td>
                <%= Html.Encode(item.lname) %>,&nbsp;<%= Html.Encode(item.fname) %>
            </td>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.director_id }) %>
            </td>
        <%= ((i % 4) == 0) ? "</tr><tr>" : "" %>
    
    <% } %>
        </tr>
    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

