<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MovieDB.Models.Director>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateModal</title>
</head>
<body>
    <div id='bulshavic'>
        <% using (Ajax.BeginForm("CreateModal", new AjaxOptions { UpdateTargetId = "bulshavic" })) { %>
        
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
            
            <input type='submit' value='Save' />
        
        <% } %>
    </div>
</body>
</html>
