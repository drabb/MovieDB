<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MovieDB.Models.Director>" %>

<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

<% using (Ajax.BeginForm(new AjaxOptions { OnSuccess = "createSuccess" })) {%>

    <fieldset>
        <p>
            <label for="fname">First Name:</label>
            <%= Html.TextBox("fname", Model.fname) %>
            <%= Html.ValidationMessage("fname", "*") %>
        </p>
        <p>
            <label for="lname">Last Name:</label>
            <%= Html.TextBox("lname", Model.lname) %>
            <%= Html.ValidationMessage("lname", "*") %>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>

<% } %>