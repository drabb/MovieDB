<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MovieDB.Helpers.PaginatedList<MovieDB.Models.Movie>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Movies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type='text/javascript' language='javascript'>

    $(function() {
        $('#lnkFilter').click(function() {
            $($(this).attr('href')).slideToggle(750, function() { $('#Movie_title').focus(); });
            return false;
        });
    });

</script>

    <h2>Movies</h2>

    <div style='width:870px;'>
        
        <div style='float:left;'>
            <%= Html.ActionLink("Create New", "Create") %>
        </div>
        <div style='float:right;'>
            <a id='lnkFilter' href='#pnlFilterOptions'>Find Movies</a>
        </div>
        <div style='clear:both;'></div>
        
        <div id='pnlFilterOptions' style='display:none;'>
            <% Html.RenderPartial("MovieFilter", ViewData["FilterData"] as MovieDB.ViewModels.MovieFormViewModel); %>
        </div>
        
        <div id='results'>
            <% Html.RenderPartial("MovieList", Model); %>
        </div>
    
    </div>
    
    <br />
    <a href='/Directors'>Directors</a>&nbsp;|&nbsp;<a href='/Genres'>Genres</a>
</asp:Content>

