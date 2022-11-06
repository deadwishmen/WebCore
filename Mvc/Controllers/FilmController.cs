using Business.IBusiness;
using Business.Implements;
using Mvc.Models;
using Repositori.Repositories;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmBusiness _filmBusiness;
        private readonly IFileBusiness _fileBusiness;
        public FilmController(IFilmBusiness filmBusiness, IFileBusiness fileBusiness)
        {
            _filmBusiness = filmBusiness;
            _fileBusiness = fileBusiness;
        }
        // GET: Film
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var filmViewModel = new FilmViewModel();
                var file = new List<FileViewModel>();
                var listFileModel = new List<FileViewModel>();
                var film = new List<FilmViewModel>();
                var trendFilm = new List<FilmViewModel>();
                var model = _filmBusiness.GetFilmById(id);
                var filmDto = _filmBusiness.SelectListFileByCategoryFilmID(model.CategoryFilmID);
                var fileDto = _fileBusiness.GetFileByFilmID(id);
                var listFile = _fileBusiness.GetListFile();
                var listTrendFilm = _filmBusiness.SelectListTrendFilm();
                filmViewModel.ID = model.ID;
                filmViewModel.Name = model.Name;
                filmViewModel.Description = model.Description;
                filmViewModel.Duration = model.Duration;
                filmViewModel.LinkTrailer = model.LinkTrailer;
                filmViewModel.Quality = model.Quality;
                filmViewModel.View = model.View;
                filmViewModel.Metatitle = model.Metatitle;
                filmViewModel.CreatedDate = model.CreatedDate;
                foreach(var item in fileDto)
                {
                    file.Add(new FileViewModel()
                    {
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        FilmID = item.FilmID,
                        Tag = item.Tag,
                    });
                }
                foreach (var item in listFile)
                {
                    listFileModel.Add(new FileViewModel()
                    {
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        FilmID = item.FilmID,
                        Tag = item.Tag,
                    });
                }
                foreach (var item in filmDto)
                {
                    film.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in listTrendFilm)
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
                ViewBag.Film = film;
                ViewBag.TrendFilm = trendFilm;
                ViewBag.File = file;
                ViewBag.ListFile = listFile;
                return View(filmViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult View(string w)
        {
            if (string.IsNullOrEmpty(w)) throw new ArgumentNullException(nameof(w));

            try
            {
                var filmViewModel = new FilmViewModel();
                var file = new List<FileViewModel>();
                var listFileModel = new List<FileViewModel>();
                var film = new List<FilmViewModel>();
                var trendFilm = new List<FilmViewModel>();
                var model = _filmBusiness.GetFilmById(w);
                var filmDto = _filmBusiness.SelectListFileByCategoryFilmID(model.CategoryFilmID);
                var fileDto = _fileBusiness.GetFileByFilmID(w);
                var listFile = _fileBusiness.GetListFile();
                var listTrendFilm = _filmBusiness.SelectListTrendFilm();
                filmViewModel.ID = model.ID;
                filmViewModel.Name = model.Name;
                filmViewModel.Description = model.Description;
                filmViewModel.Duration = model.Duration;
                filmViewModel.LinkTrailer = model.LinkTrailer;
                filmViewModel.Quality = model.Quality;
                filmViewModel.View = model.View;
                filmViewModel.Metatitle = model.Metatitle;
                filmViewModel.CreatedDate = model.CreatedDate;
                foreach (var item in fileDto)
                {
                    file.Add(new FileViewModel()
                    {
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        FilmID = item.FilmID,
                        Tag = item.Tag,
                    });
                }
                foreach (var item in listFile)
                {
                    listFileModel.Add(new FileViewModel()
                    {
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        FilmID = item.FilmID,
                        Tag = item.Tag,
                    });
                }
                foreach (var item in filmDto)
                {
                    film.Add(new FilmViewModel()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        Duration = item.Duration,
                        Quality = item.Quality,
                        Metatitle = item.Metatitle,
                    });
                }
                foreach (var item in listTrendFilm)
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
                ViewBag.Film = film;
                ViewBag.TrendFilm = trendFilm;
                ViewBag.File = file;
                ViewBag.ListFile = listFile;
                ViewBag.File = _fileBusiness.GetFileByFilmID(w);
                ViewBag.ListFile = _fileBusiness.GetListFile();
                ViewBag.Film = _filmBusiness.SelectListFileByCategoryFilmID(model.CategoryFilmID);
                ViewBag.TrendFilm = _filmBusiness.SelectListTrendFilm();
                return View(filmViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}