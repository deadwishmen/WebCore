using Business.IBusiness;
using Mvc.Models;
using Repositori.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public LoginController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username,string Password)
        {
            if (string.IsNullOrEmpty(Username)) throw new ArgumentNullException(nameof(Username));
            if (string.IsNullOrEmpty(Password)) throw new ArgumentNullException(nameof(Password));
            try
            {
                var model = new UserRepository();
                var value = _userBusiness.LoginUserAdmin(Username, Password);
                if (value == 1)
                {
                    ViewBag.validation = "Username không tồn tại";
                }
                else
                {
                    if (value == 2)
                    {
                        ViewBag.validation = "Password không đúng";
                    }
                    else
                    {
                        var loginUser = new Mvc.Models.LoginModel();
                        loginUser.UserName = Username;
                        loginUser.Password = Password;
                        loginUser.TypeUser = value - 2;
                        Session["LoginModel"] = loginUser;
                        if (value == 3)
                        {
                            var loginmodel = new Mvc.Areas.Admin.Models.LoginModel();
                            loginmodel.UserName = Username;
                            loginmodel.Password = Password;
                            loginmodel.TypeUser = value - 2;
                            Session["LoginModelAdmin"] = loginmodel;
                            return Redirect("/Admin/Home/Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}