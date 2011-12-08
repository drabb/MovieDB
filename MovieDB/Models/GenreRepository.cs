using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public class GenreRepository
    {
        private MovieDBDataContext db = new MovieDBDataContext();

        public IEnumerable<Genre> GetAllGenres()
        {
            return db.Genres.OrderBy(g => g.genre_name);
        }

        public Genre GetGenre(int id)
        {
            return db.Genres.SingleOrDefault<Genre>(g => g.genre_id == id);
        }

        public void Add(Genre newGenre)
        {
            db.Genres.InsertOnSubmit(newGenre);
        }

        public void Delete(Genre removeGenre)  //TODO: check foreign key here
        {
            db.Genres.DeleteOnSubmit(removeGenre);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
