using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Filters
{
    // Filter for user authentication.
    public class AuthFilter : ActionFilterAttribute
    {
        // OnActionExecuted
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (HttpContext.Current.Session["loggedUser"] == null)
            {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}