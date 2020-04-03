using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIUB.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = Session["userID"] as string;
            if (string.IsNullOrEmpty(name))
            {
                Response.Redirect("/");
            }
        }
    }
}