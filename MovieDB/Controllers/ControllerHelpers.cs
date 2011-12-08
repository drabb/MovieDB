using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieDB.Models;

namespace MovieDB.Controllers
{
    public static class ControllerHelpers
    {
        public static void AddRuleViolations(this ModelStateDictionary modelState, IEnumerable<RuleViolation> errors)
        {
            foreach (var issue in errors)
                modelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
        }
    }
}
