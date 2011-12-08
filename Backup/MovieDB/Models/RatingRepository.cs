using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MovieDB.Models;

namespace MovieDB.Models
{
    public class RatingRepository
    {
        private MovieDBDataContext db = new MovieDBDataContext();

        public IEnumerable<Rating> GetAllRatings()
        {
            return db.Ratings.OrderBy(r => r.rating_name);
        }
    }
}
