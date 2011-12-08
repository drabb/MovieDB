using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public partial class Director
    {
        public bool IsValid { get { return (GetRuleViolations().Count() == 0); } }
        public string FullName { get { return lname + ", " + fname; } }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(fname))
                yield return new RuleViolation("First name is a required field.", "fname");

            if (String.IsNullOrEmpty(lname))
                yield return new RuleViolation("Last name is a required field.", "lname");

            using (MovieDBDataContext db = new MovieDBDataContext())
            {
                if (db.Directors.Where(d => d.fname == fname && d.lname == lname).Count() > 0)
                    yield return new RuleViolation("Director '" + FullName + "' already exists.", "FullName");
            }
            
            yield break;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (!IsValid) throw new ApplicationException("Rule violations prevent saving");
        }
    }
}
