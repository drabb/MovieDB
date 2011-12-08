<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MovieDB.ViewModels.MovieFormViewModel>" %>

<script type='text/javascript' language='javascript'>

    var minYear = <%= Html.Encode(ViewData["YearMin"]) %>;
    var maxYear = <%= Html.Encode(ViewData["YearMax"]) %>;
    
    var minLength = <%= Html.Encode(ViewData["LengthMin"]) %>;
    var maxLength = <%= Html.Encode(ViewData["LengthMax"]) %>;
    
    $(function() {
        
        $('#slide-year').slider({
            range: true,
            min: minYear,
            max: maxYear,
            values: [minYear, maxYear],
            slide: function(event, ui) {
                $('#slide-year-label').html('From ' + ui.values[0] + ' to ' + ui.values[1]);
                $('#Movie_year_range').val(ui.values[0] + ',' + ui.values[1]);
            }
        });
        
        $('#slide-length').slider({
            range: true,
            min: minLength,
            max: maxLength,
            values: [minLength, maxLength],
            slide: function(event, ui) {
                $('#slide-length-label').html(ui.values[0] + ' to ' + ui.values[1] + ' mins');
                $('#Movie_length_range').val(ui.values[0] + ',' + ui.values[1]);
            }
        });
        
        $('#slide-year-label').html('From ' + minYear + ' to ' + maxYear);
        $('#Movie_year_range').val(minYear + ',' + maxYear);
        
        $('#slide-length-label').html(minLength + ' to ' + maxLength + ' mins');
        $('#Movie_length_range').val(minLength + ',' + maxLength);
    });

</script>


<% using (Ajax.BeginForm("MovieSearch", new AjaxOptions { UpdateTargetId = "results" })) { %>
            
<fieldset>
    
    <div style='width:350px; float:left;'> <!-- left side -->
        <p>
            <label for='Movie.title'>Title:</label>
            <%= Html.TextBox("Movie.title")%>
        </p>
        <p>
            <label for='genre_id'>Genre:</label>
            <%= Html.DropDownList("Movie.genre_id", Model.Genres, " -- Select -- ", new { style = "width:150px;" })%>
        </p>
        <p>
            <label for='rating_id'>Rating:</label>
            <%= Html.DropDownList("Movie.rating_id", Model.Ratings, " -- Select -- ", new { style = "width:150px;" })%>
        </p>
        <p>
            <label for='location_id'>Location:</label>
            <%= Html.DropDownList("Movie.location_id", Model.Locations, " -- Select -- ", new { style = "width:150px;" })%>
        </p>
    </div>
    
    <div style='width:350px; float:left;'> <!-- right side -->
    
        <div style='margin:7px 0px;'> 
            <label for='Movie.title' style='margin-bottom:10px;'>Year:</label>
            
            <div style='margin:-3px 0px 0px 17px; width:165px;'>
                <div id='slide-year' style='width:150px; line-height:10px;'></div>
                <div id='slide-year-label' style='font:10px Arial; margin:4px 8px; float:right;'></div>
            </div>
        </div>
        <div style='clear:right; margin:10px 0px;'>
            <label for='Movie.length' style='margin-bottom:10px;'>Length (mins):</label>
            
            <div style='margin:-3px 0px 0px 17px; width:165px;'>
                <div id='slide-length' style='width:150px; line-height:10px;'></div>
                <div id='slide-length-label' style='font:10px Arial; margin:4px 8px; float:right;'></div>
            </div>        
        </div>
        
        <p>
        
        </p>
        
        <br /><br />
        <p>
            <input value='filter' type='submit' />
        </p>
    </div>

</fieldset>
    
<%= Html.Hidden("Movie.year_range") %>
<%= Html.Hidden("Movie.length_range") %>

<% } %>