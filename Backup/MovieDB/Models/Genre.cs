using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB.Models
{
    public partial class Genre
    {
        public bool IsValid { get { return (GetRuleViolations().Count() == 0); } }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(genre_name))
                yield return new RuleViolation("Genre name is a required field.", "genre_name");

            yield break;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (!IsValid) throw new ApplicationException("Rule violations prevent saving");
        }
    }
}
