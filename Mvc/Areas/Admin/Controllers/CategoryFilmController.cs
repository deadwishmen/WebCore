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
    public class CategoryFilmController : BaseController
    {

        private readonly ICategoryFilmBusiness _categoryFimBusiness;
        private readonly IUserBusiness _userBusiness;
        public CategoryFilmController(ICategoryFilmBusiness categoryFilmBusiness,IUserBusiness userBusiness)
        {
            _categoryFimBusiness = categoryFilmBusiness;
            _userBusiness = userBusiness;
        }
        // GET: Admin/CategoryFilm
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            try
            {
                long total = 0;
                var model = _categoryFimBusiness.GetListPage(ref total, page, pageSize);
                var categoryViewModel = new List<CategoryViewModel>();
                foreach (var item in model)
                {
                    categoryViewModel.Add(new CategoryViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Metatitle = item.Metatitle,
                        CreatedDate = item.CreatedDate,
                        UserID = item.UserID,
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
                return View(categoryViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "CategoryFilm");
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(id);
            try
            {
                _categoryFimBusiness.DeleteCategory(id);
                return Json(new
                {
                    status = true
                });
            }
            catch(Exception ex)
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
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var LoginModel = (LoginModel)Session["LoginModelAdmin"];
                var id = _userBusiness.getIdByUsername(LoginModel.UserName);
                var categoryDto = new CategoryFilmDTO();
                categoryDto.Name = categoryViewModel.Name;
                categoryDto.UserID = id;
                var check = _categoryFimBusiness.CreateCategoryFilm(categoryDto);
                if (check)
                {
                    return RedirectToAction("index", "CategoryFilm");
                }
                    
            }
            catch(Exception ex)
            {
            }
            ViewBag.Message = "Tạo loại phim không hoàn thành";
            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _categoryFimBusiness.GetCategoryFilmById(id);
                var categoryViewModel = new CategoryViewModel();
                categoryViewModel.ID = model.ID;
                categoryViewModel.Name = model.Name;
                categoryViewModel.UserID = model.UserID;
                return View(categoryViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "CategoryFilm");
            }
            
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var categoryDto = new CategoryFilmDTO();
                categoryDto.Name = categoryViewModel.Name;
                categoryDto.UserID = categoryViewModel.UserID;
                var checkEdit = _categoryFimBusiness.EditCategoryFilm(categoryDto);
                if (checkEdit)
                {
                    return RedirectToAction("Index", "CategoryFilm");
                }
                else
                {
                    ViewBag.Message = "Tên loại phim đã tồn tại";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa loại phim thất bại";
            }
            return View(categoryViewModel);
        }
    }
}