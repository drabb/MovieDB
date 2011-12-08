using System;
namespace MovieDB.Models
{
    public interface IMovieRepository
    {
        void Add(Movie newMovie);
        void Delete(Movie removeMovie);
        System.Linq.IQueryable<Movie> GetAllMovies();
        Movie GetMovie(int id);
        void Save();
        System.Linq.IQueryable<Movie> Search(string movie_title, string yearRange, string lengthRange, int? genre_id, int? rating_id, int? director_id, int? location_id);
    }
}
