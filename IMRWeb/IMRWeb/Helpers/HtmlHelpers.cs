using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace IMR.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static string MakeActive(this UrlHelper urlHelper, string action, string controller, string area = "")
        {
            string result = "active";
            string requestContextRoute;
            string passedInRoute;

            // Get the route values from the request           
            var sb = new StringBuilder().Append(urlHelper.RequestContext.RouteData.DataTokens["area"]);
            sb.Append("/");
            sb.Append(urlHelper.RequestContext.RouteData.Values["controller"].ToString());
            sb.Append("/");
            sb.Append(urlHelper.RequestContext.RouteData.Values["action"].ToString());
            requestContextRoute = sb.ToString();

            if (string.IsNullOrWhiteSpace(area))
            {
                passedInRoute = "/" + controller + "/" + action;
            }
            else
            {
                passedInRoute = area + "/" + controller + "/" + action;
            }

            //  Are the 2 routes the same?
            if (!requestContextRoute.Equals(passedInRoute, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }
    }
}