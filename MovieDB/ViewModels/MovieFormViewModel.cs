using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieDB.Models;

namespace MovieDB.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; private set; }
        public SelectList Genres { get; private set; }
        public SelectList Locations { get; private set; }
        public SelectList Ratings { get; private set; }

        public MovieFormViewModel()
        {
            GenreRepository genreRepo = new GenreRepository();
            LocationRepository locaRepo = new LocationRepository();
            RatingRepository ratingRepo = new RatingRepository();

            Genres = new SelectList(genreRepo.GetAllGenres(), "genre_id", "genre_name");
            Locations = new SelectList(locaRepo.GetAllLocations(), "location_id", "location_name");
            Ratings = new SelectList(ratingRepo.GetAllRatings(), "rating_id", "rating_name");
        }

        public MovieFormViewModel(Movie movie)
        {
            Movie = movie;

            GenreRepository genreRepo = new GenreRepository();
            LocationRepository locaRepo = new LocationRepository();
            RatingRepository ratingRepo = new RatingRepository();

            Genres = new SelectList(genreRepo.GetAllGenres(), "genre_id", "genre_name", movie.genre_id);
            Locations = new SelectList(locaRepo.GetAllLocations(), "location_id", "location_name", movie.location_id);
            Ratings = new SelectList(ratingRepo.GetAllRatings(), "rating_id", "rating_name", movie.rating_id);
        }
    }
}
