<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MovieDB.ViewModels.MovieFormViewModel>" %>

<script type='text/javascript' language='javascript'>

    $(function() {

        $('#Movie_title').focus();

        $('#directorName').autocomplete('<%= Url.Action("DirectorSearch", "Directors") %>', {
            dataType: "json",
            formatItem: function(data, i, max, value, term) {
                return value;
            },
            parse: function(data) {
                var array = new Array();
                for (var i = 0; i < data.length; i++) {
                    var temp = data[i].FullName;
                    var tempR = data[i].FullName;
                    array[array.length] = { data: data[i], value: temp, result: tempR };
                }
                return array;
            }
        });

        $('#directorName').result(function(event, data, formatted) {
            $('#Movie_director_id').val(!data ? "-1" : "" + data.director_id);
        });

        $('#lnkNewDirector').click(function() {
            $('#modalPlaceHolder').load('/Directors/CreateModal/ #bulshavic');
            $('#modalPlaceHolder').dialog('open');
            return false;
        });

        $('#modalPlaceHolder').dialog({
            autoOpen: false,
            modal: true,
            title: 'Add Director',
            open: function() { setTimeout("$('#fname').focus();", 600); },
            close: function() { $('#Movie_director_id').val($('#Movie_director_id').val()); }
        });
    });

    function newDirectorComplete(dirID, dirName) {
        $('#Movie_director_id').val(dirID);
        $('#directorName').val(dirName);
        $('#modalPlaceHolder').dialog('close'); 
    }
</script>

<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

<% using (Html.BeginForm()) {%>

    <fieldset>
        <p>
            <label for="title">Title:</label>
            <%= Html.TextBox("Movie.title") %>
            <%= Html.ValidationMessage("title", "*") %>
        </p>
        <p>
            <label for="year">Year:</label>
            <%= Html.TextBox("Movie.year")%>
            <%= Html.ValidationMessage("year", "*") %>
        </p>
        <p>
            <label for="length">Length (minutes):</label>
            <%= Html.TextBox("Movie.length")%>
            <%= Html.ValidationMessage("length", "*") %>
        </p>
        <p>
            <label for="genre_id">Genre:</label>
            <%= Html.DropDownList("Movie.genre_id", Model.Genres) %>
            <%= Html.ValidationMessage("Movie.genre_id", "*") %>
        </p>
        <p>
            <label for="rating_id">Rating:</label>
            <%= Html.DropDownList("Movie.rating_id", Model.Ratings) %>
            <%= Html.ValidationMessage("Movie.rating_id", "*") %>
        </p>

        <p>
            <label for="director_id">Director:</label>
            <%= Html.TextBox("directorName", (Model.Movie.Director != null) ? Model.Movie.Director.FullName : "") %>
            <%= Html.Hidden("Movie.director_id") %>
            
            <a id='lnkNewDirector' href='#' class='fauxLink' style='margin-left:10px;'>add a new director</a>
            
            <div id='modalPlaceHolder'></div>
        </p>
        <p>
            <label for="location_id">Location:</label>
            <%= Html.DropDownList("Movie.location_id", Model.Locations) %>
            <%= Html.ValidationMessage("Movie.location_id", "*") %>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    
<% } %>