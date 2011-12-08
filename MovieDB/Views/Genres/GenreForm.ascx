<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MovieDB.Models.Genre>" %>

<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

<% using (Html.BeginForm()) {%>

    <fieldset>
        <p>
            <label for="genre_name">Name:</label>
            <%= Html.TextBox("genre_name", Model.genre_name) %>
            <%= Html.ValidationMessage("genre_name", "*") %>
        </p>
        <p>
            <label for="genre_desc">Description:</label>
            <%= Html.TextBox("genre_desc", Model.genre_desc) %>
            <%= Html.ValidationMessage("genre_desc", "*") %>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>

<% } %>