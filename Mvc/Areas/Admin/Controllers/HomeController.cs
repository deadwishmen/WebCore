using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["LoginModelAdmin"] = null;
            Session["LoginModel"] = null;
            return Redirect("/Home/Index");
        }
    }
}