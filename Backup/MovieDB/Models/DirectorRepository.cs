using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public class DirectorRepository
    {
        private MovieDBDataContext db = new MovieDBDataContext();

        public IEnumerable<Director> GetAllDirectors()
        {
            return db.Directors.OrderBy(d => d.lname);
        }

        public Director GetDirector(int id)
        {
            return db.Directors.SingleOrDefault<Director>(d => d.director_id == id);
        }

        public void Add(Director newDirector)
        {
            db.Directors.InsertOnSubmit(newDirector);
        }

        public void Delete(Director removeDirector)  // TODO: check foreign keys ?
        {
            db.Directors.DeleteOnSubmit(removeDirector);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
