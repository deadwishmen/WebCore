using Business.IBusiness;
using Business.Implements;
using Common.DTO;
using Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public LoginController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            var session = Session["LoginModelAdmin"];
            if (session != null )
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            try
            {
                var checkUser = _userBusiness.LoginUserAdmin(loginModel.UserName, loginModel.Password);
                if (checkUser == 1)
                {
                    ViewBag.Message = "Tên đăng nhập không tồn tại";
                }
                else
                {
                    if (checkUser == 2)
                    {
                        ViewBag.Message = "Mật khẩu không đúng";
                    }
                    else
                    {
                        if (checkUser == 3)
                        {
                            loginModel.TypeUser = 1;
                            Session["LoginModelAdmin"] = loginModel;
                            var loginUser = new Mvc.Models.LoginModel();
                            loginUser.UserName = loginModel.UserName;
                            loginUser.Password = loginModel.Password;
                            loginUser.TypeUser = loginModel.TypeUser;
                            Session["LoginModel"] = loginUser;
                            return RedirectToAction("index", "Home");
                        }
                        else
                        {
                            ViewBag.Message = "Đăng nhập không thành công";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Đăng nhập không thành công";
            }
            return View(loginModel);
        }
    }
}