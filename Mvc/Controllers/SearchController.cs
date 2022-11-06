using Business.IBusiness;
using Business.Implements;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class SearchController : Controller
    {
        private readonly IFilmBusiness _filmBusiness;
        private readonly IFileBusiness _fileBusiness;
        public SearchController(IFilmBusiness filmBusiness,IFileBusiness fileBusiness)
        {
            _filmBusiness = filmBusiness;
            _fileBusiness = fileBusiness;
        }
        // GET: Search
        public ActionResult Index(string q,int page=1,int pageSize=3)
        {
            if (string.IsNullOrEmpty(q)) throw new ArgumentNullException(nameof(q));
            try
            {
                long total = 0;
                var model = _filmBusiness.SelectSearch(ref total, q, page, pageSize);
                var filmViewModel = new List<FilmViewModel>();
                var listFile = new List<FileViewModel>();
                var trendFilm = new List<FilmViewModel>();
                var listFileDto = _fileBusiness.GetListFile();
                var trendFilmDto = _filmBusiness.SelectListTrendFilm();
                foreach(var item in model)
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
                foreach (var item in listFileDto)
                {
                    listFile.Add(new FileViewModel()
                    {
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        FilmID = item.FilmID,
                        Tag = item.Tag,
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
                ViewBag.ListFile = listFile;
                ViewBag.TrendFilm = trendFilm;
                return View(filmViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}