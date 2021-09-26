using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthJang.Common
{
    public class LoginFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["USER_LOGIN_ID"] == null )
            {
                filterContext.HttpContext.Response.Redirect("/Account/Login");
                return;
            }


        }
    }
}