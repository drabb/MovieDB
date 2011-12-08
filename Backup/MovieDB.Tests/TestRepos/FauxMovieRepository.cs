using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MovieDB.Models;

namespace MovieDB.Tests.TestRepos
{
    class FauxMovieRepository : IMovieRepository
    {
        List<Movie> movieList;

        public FauxMovieRepository(List<Movie> movies)
        {
            movieList = movies;
        }

        public void Add(Movie newMovie)
        {
            movieList.Add(newMovie);
        }

        public void Delete(Movie removeMovie)
        {
            movieList.Remove(removeMovie);
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return movieList.AsQueryable();
        }

        public Movie GetMovie(int id)
        {
            return movieList.Single(m => m.movie_id == id);
        }

        public void Save()
        {
            foreach (Movie movie in movieList)
            {
                if (!movie.IsValid)
                    throw new ApplicationException("Rule violations.");
            }
        }

        public IQueryable<Movie> Search(string movie_title, string yearRange, string lengthRange, int? genre_id, int? rating_id, int? director_id, int? location_id)
        {
            throw new NotImplementedException();
        }
    }
}
