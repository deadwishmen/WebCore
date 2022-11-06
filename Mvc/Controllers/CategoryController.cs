using Business.IBusiness;
using Business.Implements;
using Mvc.Models;
using Repositori.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryFilmBusiness _categoryFilmBusiness;
        private readonly IFileBusiness _fileBusiness;
        private readonly IFilmBusiness _filmBusiness;
        public CategoryController(ICategoryFilmBusiness categoryFilmBusiness,IFilmBusiness filmBusiness,IFileBusiness fileBusiness)
        {
            _categoryFilmBusiness = categoryFilmBusiness;
            _fileBusiness = fileBusiness;
            _filmBusiness = filmBusiness;
        }
        [HttpGet]
        public ActionResult Index(string id,int page=1,int pageSize=3)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                long ID = long.Parse(id);
                var pagination = new PaginationModel();
                long total = 0;
                var filmModel = new List<FilmViewModel>();
                var fileViewModel = new List<FileViewModel>();
                var filmViewModel = new List<FilmViewModel>();
                var model = _filmBusiness.getListFilmByCategoryPage(ref total, id, page, pageSize);
                var listFile = _fileBusiness.GetListFile();
                var trendFilm = _filmBusiness.SelectListTrendFilm();
                foreach(var item in listFile)
                {
                    fileViewModel.Add(new FileViewModel()
                    {
                        FileType = item.FileType,
                        FileContent = item.FileContent,
                        ID = item.ID,
                        Tag = item.Tag,
                        FilmID = item.FilmID,
                        Status = item.Status,
                    });
                }
                foreach(var item in trendFilm)
                {
                    filmViewModel.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in model)
                {
                    filmModel.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                ViewBag.ID = id;
                pagination.Total = total;
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
                ViewBag.ListFile = listFile;
                ViewBag.TrendFilm = trendFilm;
                return View(filmModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "Home");
            }
            
        }
        [HttpGet]
        public ActionResult Tag(string year,int page=1,int pageSize=3)
        {
            if (string.IsNullOrEmpty(year)) throw new ArgumentNullException(nameof(year));
            try
            {
                var pagination = new PaginationModel();
                long total = 0;
                var filmModel = new List<FilmViewModel>();
                var fileViewModel = new List<FileViewModel>();
                var filmViewModel = new List<FilmViewModel>();
                var model = _filmBusiness.GetListFilmByYear(year, ref total, page, pageSize);
                var listFile = _fileBusiness.GetListFile();
                var trendFilm = _filmBusiness.SelectListTrendFilm();
                foreach (var item in listFile)
                {
                    fileViewModel.Add(new FileViewModel()
                    {
                        FileType = item.FileType,
                        FileContent = item.FileContent,
                        ID = item.ID,
                        Tag = item.Tag,
                        FilmID = item.FilmID,
                        Status = item.Status,
                    });
                }
                foreach (var item in trendFilm)
                {
                    filmViewModel.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in model)
                {
                    filmModel.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                ViewBag.Year = year;
                pagination.Total = total;
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
                ViewBag.ListFile = listFile;
                ViewBag.TrendFilm = trendFilm;
                return View(filmModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}