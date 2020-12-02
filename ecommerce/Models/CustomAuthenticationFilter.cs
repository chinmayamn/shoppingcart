using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ecommerce.Models
{
    public class CustomAuthenticationFilter: ActionFilterAttribute, IAuthenticationFilter
    {
        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["theme"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "controller", "Account" },
                    { "action", "Login" } });
            }
        }
    }
}