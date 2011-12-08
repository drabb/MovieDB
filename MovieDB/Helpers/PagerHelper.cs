using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MovieDB.Helpers
{
    public static class PagerHelper
    {
        public static string Pager(this HtmlHelper helper, int pageIndex, int pageCount)
        {
            StringBuilder pagerLinks = new StringBuilder("<div id='pages'>");

            if (pageIndex < 1) pageIndex = 0;

            for (int i = 0; i < pageCount; i++)
            {
                string pageLink = (i == pageIndex)
                    ? "<span id='curPage'>" + (i + 1).ToString() + "</span>"
                    : helper.RouteLink((i + 1).ToString(), "MoviesListing", new { page = i }).ToString();

                pagerLinks.Append(pageLink);
            }

            return pagerLinks.Append("</div>").ToString();
        }
    }
}
