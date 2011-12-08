using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public class LocationRepository
    {
        private MovieDBDataContext db = new MovieDBDataContext();

        public IEnumerable<Location> GetAllLocations()
        {
            return db.Locations;
        }

        public Location GetLocation(int id)
        {
            return db.Locations.SingleOrDefault<Location>(l => l.location_id == id);
        }
    
    }
}
