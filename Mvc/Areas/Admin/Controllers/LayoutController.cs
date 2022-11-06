using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            return PartialView();
        }
    }
}