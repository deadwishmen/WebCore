using Mvc.Areas.Admin.Models;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Mvc.Areas.Admin.Models.LoginModel)Session["LoginModelAdmin"]; // kiểm tra thử đã đăng nhập chưa 
            if (session == null || session.TypeUser != 1)
            {
                Session["LoginModel"] = null;
                Session["LoginModelAdmin"] = null;
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}