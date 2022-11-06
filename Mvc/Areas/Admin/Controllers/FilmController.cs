using Business.IBusiness;
using Business.Implements;
using Business.Tool;
using Common.DTO;
using Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IFilmBusiness _filmBusiness;
        private readonly ICategoryFilmBusiness _categoryFilmBusiness;
        private readonly IUserBusiness _userBusiness;
        
        public FilmController(IFilmBusiness filmBusiness,ICategoryFilmBusiness categoryFilmBusiness,IUserBusiness userBusiness)
        {
            _filmBusiness = filmBusiness;
            _categoryFilmBusiness = categoryFilmBusiness;
            _userBusiness = userBusiness;
        }
        // GET: Admin/Film
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            try
            {
                var pagination = new PaginationModel();
                long total = 0;
                var filmViewModel = new List<FilmViewModel>();
                var model = _filmBusiness.GetListPage(ref total, page, pageSize);
                foreach(var item in model)
                {
                    filmViewModel.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        CategoryFilmID = item.CategoryFilmID,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Status = item.Status,
                        LinkTrailer = item.LinkTrailer,
                        View = item.View,
                        Metatitle = item.Metatitle,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy
                    }) ;
                }
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
                return View(filmViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "Home");
            }
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var list = _categoryFilmBusiness.GetNameCategoryFilm();

                List<SelectListItem> ListCategory = new List<SelectListItem>();
                foreach (var item in list)
                {
                    ListCategory.Add(new SelectListItem() { Text = item.Name, Value = item.ID.ToString() });
                }
                ViewBag.CategoryFilmID = new SelectList(ListCategory, "Value", "Text");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Film");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(FilmViewModel filmViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                var loginModel = (LoginModel)Session["LoginModelAdmin"];
                filmViewModel.CreatedBy = _userBusiness.getIdByUsername(loginModel.UserName);
                var filmDto = new FilmDTO();
                filmDto.Name = filmViewModel.Name;
                filmDto.CreatedBy = filmViewModel.CreatedBy;
                filmDto.Description = filmViewModel.Description;
                filmDto.Duration = filmViewModel.Duration;
                filmDto.LinkTrailer = filmViewModel.LinkTrailer;
                filmDto.Quality = filmViewModel.Quality;
                filmDto.CategoryFilmID = filmViewModel.CategoryFilmID;
                var check = _filmBusiness.CreateFilm(filmDto);
                if (check)
                {
                    return RedirectToAction("Index", "Film");
                }
                ViewBag.Message("Film đã tồn tại");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Thêm phim thất bại";
            }
            return View(filmViewModel);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            try
            {
                _filmBusiness.DeleteFilm(id);
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
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var filmViewModel = new FilmViewModel();
                var model = _filmBusiness.GetFilmById(id);
                var list = _categoryFilmBusiness.GetNameCategoryFilm();
                filmViewModel.Description = model.Description;
                filmViewModel.Duration = model.Duration;
                filmViewModel.LinkTrailer = model.LinkTrailer;
                filmViewModel.Name = model.Name;
                filmViewModel.Quality = model.Quality;
                List<SelectListItem> ListCategory = new List<SelectListItem>();
                foreach (var item in list)
                {
                    ListCategory.Add(new SelectListItem() { Text = item.Name, Value = item.ID.ToString() });
                }
                ViewBag.CategoryFilmID = new SelectList(ListCategory, "Value", "Text");
                return View(filmViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Edit(FilmViewModel filmViewModel)
        {
            //var context = new ValidationContext(filmDTO, serviceProvider: null, items: null);
            //var validationResults = new List<ValidationResult>();
            //bool isValid = Validator.TryValidateObject(filmDTO, context, validationResults, true);
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var loginModel = (LoginModel)Session["LoginModelAdmin"];
                var filmDto = new FilmDTO();
                filmViewModel.CreatedBy = _userBusiness.getIdByUsername(loginModel.UserName);
                filmDto.CategoryFilmID = filmViewModel.CategoryFilmID;
                filmDto.CreatedBy = filmViewModel.CreatedBy;
                filmDto.Name = filmViewModel.Name;
                filmDto.LinkTrailer = filmViewModel.LinkTrailer;
                filmDto.Quality = filmViewModel.Quality;
                filmDto.Duration = filmViewModel.Duration;
                var checkEdit = _filmBusiness.EditFilm(filmDto);
                if (checkEdit == true)
                {
                    return RedirectToAction("Index", "Film");
                }
                else
                {
                    ViewBag.Message = "Phim này đã tồn tại";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa phim thất bại";
            }
            return View(filmViewModel);
        }
    }
}