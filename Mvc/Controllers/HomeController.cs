

using Repositori.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Common.Commons;
using Business.Implements;
using Common.DTO;
using Mvc.Models;
using Business.IBusiness;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IFilmBusiness _filmBusiness;
        private readonly IFileBusiness _fileBusiness;
        private readonly ICategoryFilmBusiness _categoryFilmBusiness;
        public HomeController(IUserBusiness userBusiness,IFileBusiness fileBusiness,IFilmBusiness filmBusiness,ICategoryFilmBusiness categoryFilmBusiness)
        {
            _userBusiness = userBusiness;
            _filmBusiness = filmBusiness;
            _fileBusiness = fileBusiness;
            _categoryFilmBusiness = categoryFilmBusiness;
        }
        public ActionResult Index()
        {
            try
            {
                var listCategoryViewModel = new List<CategoryViewModel>();
                var listViet = new List<FilmViewModel>();
                var listHoatHinh = new List<FilmViewModel>();
                var trendFilm = new List<FilmViewModel>();
                long countTrendFilm = 0;
                var trendFilmDto = _filmBusiness.SelectTrendFilmPageHome(ref countTrendFilm);
                var newFilmDto = _filmBusiness.GetNewFilm();
                var newFilm = new List<FilmViewModel>();
                var listFileDto = _fileBusiness.GetListFile();
                var listFile = new List<FileViewModel>();
                var categoryDto = _categoryFilmBusiness.GetCategoryFilms();

                foreach (var item in listFileDto)
                {
                    listFile.Add(new FileViewModel()
                    {
                        ID = item.ID,
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        Tag = item.Tag,
                        FilmID = item.FilmID,
                        Status = item.Status
                    });
                }
                foreach (var item in trendFilmDto)
                {
                    trendFilm.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in newFilmDto)
                {
                    newFilm.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in categoryDto)
                {
                    listCategoryViewModel.Add(new CategoryViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Metatitle = item.Metatitle,
                        CreatedDate = item.CreatedDate,
                    });
                }
                foreach (var item in categoryDto)
                {
                    if (item.Name == "Phim việt")
                    {
                        var listVietDto = _filmBusiness.GetListViet(item.ID);
                        foreach (var childitem in listVietDto)
                        {
                            listViet.Add(new FilmViewModel()
                            {
                                ID = childitem.ID,
                                Name = childitem.Name,
                                Description = childitem.Description,
                                Duration = childitem.Duration,
                                Quality = childitem.Quality,
                                Metatitle = childitem.Metatitle,
                            });
                        }
                        ViewBag.ListViet = listViet;
                        break;
                    }
                }
                foreach (var item in categoryDto)
                {
                    if (item.Name == "Hoạt hình")
                    {
                        var listHoatHinhDto = _filmBusiness.GetListViet(item.ID);
                        foreach (var childitem in listHoatHinhDto)
                        {
                            listHoatHinh.Add(new FilmViewModel()
                            {
                                ID = childitem.ID,
                                Name = childitem.Name,
                                Description = childitem.Description,
                                Duration = childitem.Duration,
                                Quality = childitem.Quality,
                                Metatitle = childitem.Metatitle,
                            });
                        }
                        ViewBag.ListHoatHinh = listHoatHinh;
                        break;
                    }
                }
                ViewBag.CountTrendFilm = countTrendFilm;
                ViewBag.TrendFilm = trendFilm;
                ViewBag.NewFilm = newFilm;
                ViewBag.ListFile = listFile;
                ViewBag.CountNewFilm = _filmBusiness.GetCountNewFilm();
                ViewBag.Category = listCategoryViewModel;
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = (LoginModel)Session["LoginModel"];
            ViewBag.Category = _categoryFilmBusiness.GetCategoryFilms();
            if (model != null)
            {
                ViewBag.Account = model.UserName;
            }
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
       
        public ActionResult Logout()
        {
            Session["LoginModel"] = null;
            Session["LoginModelAdmin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}