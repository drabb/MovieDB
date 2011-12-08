using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public class MovieRepository : MovieDB.Models.IMovieRepository
    {
        private MovieDBDataContext db = new MovieDBDataContext();

        public IQueryable<Movie> GetAllMovies()
        {
            return db.Movies;
        }

        public Movie GetMovie(int id)
        {
            return db.Movies.SingleOrDefault<Movie>(m => m.movie_id == id);
        }

        public void Add(Movie newMovie)
        {
            db.Movies.InsertOnSubmit(newMovie);
        }

        public void Delete(Movie removeMovie)
        {
            db.Movies.DeleteOnSubmit(removeMovie);
        }

        public IQueryable<Movie> Search(string movie_title, string yearRange, string lengthRange, int? genre_id, int? rating_id, int? director_id, int? location_id)
        {
            //join g in db.Genres on m.genre_id equals g.genre_id

            string[] years = yearRange.Split(',');
            string[] lengths = lengthRange.Split(',');

            return (from m in db.Movies
                    where (string.IsNullOrEmpty(movie_title) || m.title.Contains(movie_title)) &&
                          (genre_id == null || m.genre_id == genre_id) &&
                          (rating_id == null || m.rating_id == rating_id) &&
                          (director_id == null || m.director_id == director_id) &&
                          (location_id == null || m.location_id == location_id) &&
                          (m.year >= int.Parse(years[0]) && m.year <= int.Parse(years[1])) &&
                          (m.length >= int.Parse(lengths[0]) && m.length <= int.Parse(lengths[1]))
                    orderby m.title
                    select m);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
