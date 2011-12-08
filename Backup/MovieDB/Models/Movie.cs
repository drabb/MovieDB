using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace MovieDB.Models
{
    public partial class Movie
    {
        public bool IsValid { get { return (GetRuleViolations().Count() == 0); } }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(title))
                yield return new RuleViolation("Movie title is a required field.", "title");

            if (year == null)
                yield return new RuleViolation("Movie year is a required field.", "year");

            if (year < 1910 || year > DateTime.Now.Year + 2)
                yield return new RuleViolation("Movie year must be between 1910 and " + (DateTime.Now.Year + 2).ToString() + ".", "year");

            if (length <= 0 || length >= int.MaxValue)
                yield return new RuleViolation("Movie length must be greater than 0 minutes.", "length");

            using (MovieDBDataContext db = new MovieDBDataContext())
            {
                var existingMovies = db.Movies.Where(m => m.title.Equals(title));

                if (existingMovies.Count() > 0 && existingMovies.First<Movie>().movie_id != this.movie_id)
                    yield return new RuleViolation("Movie with title '" + title + "' already exists.", "title");
            }

            //TODO: add more violations, director, genre, rating, etc

            yield break;
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid) throw new ApplicationException("Rule violations prevent saving.");
        }
    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
