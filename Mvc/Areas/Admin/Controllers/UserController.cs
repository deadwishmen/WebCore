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
    public class UserController : BaseController
    {
        // GET: Admin/User
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public ActionResult Index(int page=1,int pageSize=1)
        {
            try
            {
                long total = 0;
                var model = _userBusiness.GetListPage(ref total, page, pageSize);
                var userViewModel = new List<UserViewModel>();
                foreach(var item in model)
                {
                    userViewModel.Add(new UserViewModel()
                    {
                        ID = item.ID,
                        Username = item.Username,
                        Password = item.Password,
                        Name = item.Name,
                        BirthDay = item.BirthDay,
                        CreatedDate = item.CreatedDate,
                        Email = item.Email,
                        Phone = item.Phone,
                        Sex = item.Sex,
                        Status = item.Status,
                        UserType = item.UserType
                    });
                }
                var pagination = new PaginationModel();
                pagination.Total = total;
                pagination.Show = (total != 0 ? ((page - 1) * pageSize) + 1 : 0);
                pagination.ShowTo = (((page - 1) * pageSize) + 1) + model.Count() - 1;
                pagination.Page = page;
                int maxPage = 5;
                int totalPage = 0;
                totalPage = (int)Math.Ceiling((double)((double)total / (double)pageSize));
                pagination.TotalPage = totalPage;
                pagination.MaxPage = 5;
                pagination.First = 1;
                pagination.Last = totalPage;
                pagination.Next = page + 1;
                pagination.Prev = page - 1;
                ViewBag.Pagination = pagination;
                return View(userViewModel);
            }
            catch(Exception ex)
            {
                return View(); // error 
            }
            
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            try
            {
                if (_userBusiness.DeleteUser(id) == true)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false
                    });
                }
            }catch(Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View(userViewModel);
            try
            {
                var userDto = new UserDTO();
                userDto.Username = userViewModel.Username;
                userDto.Password = userViewModel.Password;
                userDto.BirthDay = userViewModel.BirthDay;
                userDto.Name = userViewModel.Name;
                userDto.Phone = userViewModel.Phone;
                userDto.Sex = userViewModel.Sex;
                userDto.UserType = userViewModel.UserType;
                userDto.Email = userViewModel.Email;
                var checkCreate = _userBusiness.createUser(userDto);
                if (checkCreate == 0)
                {
                    ViewBag.Message = "Username đã tồn tại";
                }
                else
                {
                    if (checkCreate == 1)
                    {
                        ViewBag.Message = "Email đã tồn tại";
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Tạo người dùng thất bại";
            }
            return View(userViewModel);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _userBusiness.GetUser(id);
                var userViewModel = new UserViewModel();
                userViewModel.Username = model.Username;
                userViewModel.Password = model.Password;
                userViewModel.Phone = model.Phone;
                userViewModel.Sex = model.Sex;
                userViewModel.Name = model.Name;
                userViewModel.UserType = model.UserType;
                userViewModel.BirthDay = model.BirthDay;
                userViewModel.Email = model.Email;
                return View(userViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "User");
            }
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                var userDto = new UserDTO();
                userDto.Password = userViewModel.Password;
                userDto.Phone = userViewModel.Phone;
                userDto.Sex = userViewModel.Sex;
                userDto.UserType = userViewModel.UserType;
                userDto.BirthDay = userViewModel.BirthDay;
                userDto.Email = userViewModel.Email;
                var checkEdit = _userBusiness.CheckEditUser(userDto);
                if (checkEdit == 1)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.Message = "Email đã tồn tại";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Thay đổi user thất bại";
            }
            return View(userViewModel);
        }
    }
}