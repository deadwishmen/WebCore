using Business.Implements;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Areas.Admin.Models;
using Business.IBusiness;

namespace Mvc.Areas.Admin.Controllers
{
    public class FileController : BaseController
    {
        private readonly IFileBusiness _fileBusiness;
        private readonly IFilmBusiness _filmBusiness;
        private readonly IUserBusiness _userBusiness;
        public FileController(IFileBusiness fileBusiness,IFilmBusiness filmBusiness,IUserBusiness userBusiness)
        {
            _fileBusiness = fileBusiness;
            _filmBusiness = filmBusiness;
            _userBusiness = userBusiness;
        }
        // GET: Admin/File
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            try
            {
                long total = 0;
                var fileViewModel = new List<FileViewModel>();
                var pagination = new PaginationModel();
                var model = _fileBusiness.GetListPage(ref total, page, pageSize);
                foreach(var item in model)
                {
                    fileViewModel.Add(new FileViewModel()
                    {
                        ID = item.ID,
                        FileContent = item.FileContent,
                        FileType = item.FileType,
                        Tag = item.Tag,
                        FilmID = item.FilmID,
                        UpdatedDate = item.UpdatedDate,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        Status = item.Status
                    });
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
                return View(fileViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(id);
            try
            {
                _fileBusiness.DeleteFile(id);
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
            try
            {
                var list = _filmBusiness.GetFilms();
                List<SelectListItem> ListFilm = new List<SelectListItem>();
                List<SelectListItem> ListType = new List<SelectListItem>();
                ListType.Add(new SelectListItem() { Text = "Hình ảnh", Value = "1" });
                ListType.Add(new SelectListItem() { Text = "Video", Value = "2" });
                ViewBag.ListType = new SelectList(ListType, "Value", "Text");
                foreach (var item in list)
                {
                    ListFilm.Add(new SelectListItem() { Text = item.Name, Value = item.ID.ToString() });
                }
                ViewBag.ListFilm = new SelectList(ListFilm, "Value", "Text");
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "File");
            }
        }
        [HttpPost]
        public ActionResult Create(FileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var LoginModel = (LoginModel)Session["LoginModelAdmin"];
                fileViewModel.CreatedBy = _userBusiness.getIdByUsername(LoginModel.UserName);
                var fileDto = new FileDTO();
                fileDto.FileContent = fileViewModel.FileContent;
                fileDto.FileType = fileViewModel.FileType;
                fileDto.FilmID = fileViewModel.FilmID;
                fileDto.Tag = fileViewModel.Tag;
                fileDto.CreatedBy = fileViewModel.CreatedBy;
                _fileBusiness.CreateFile(fileDto);
                return RedirectToAction("index", "File");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Thêm file thất bại";
            }
            return View(fileViewModel);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            try
            {
                var model = _fileBusiness.getFileById(id);
                var list = _filmBusiness.GetFilms();
                var fileViewModel = new FileViewModel();
                fileViewModel.FileType = model.FileType;
                fileViewModel.FileContent = model.FileContent;
                fileViewModel.CreatedBy = model.CreatedBy;
                fileViewModel.Tag = model.Tag;
                List<SelectListItem> ListFilm = new List<SelectListItem>();
                List<SelectListItem> ListType = new List<SelectListItem>();
                if (model.FileType == 1)
                {
                    ListType.Add(new SelectListItem() { Text = "Hình ảnh", Value = "1" });
                    ListType.Add(new SelectListItem() { Text = "Video", Value = "2" });
                }
                else
                {
                    ListType.Add(new SelectListItem() { Text = "Video", Value = "2" });
                    ListType.Add(new SelectListItem() { Text = "Hình ảnh", Value = "1" });
                }
                ViewBag.ListType = new SelectList(ListType, "Value", "Text");
                foreach (var item in list.Where(x => x.ID == model.FilmID))
                {
                    ListFilm.Add(new SelectListItem() { Text = item.Name, Value = item.ID.ToString() });
                }
                foreach (var item in list)
                {
                    ListFilm.Add(new SelectListItem() { Text = item.Name, Value = item.ID.ToString() });
                }
                ViewBag.ListFilm = new SelectList(ListFilm, "Value", "Text");
                return View(fileViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "File");
            }
        }
        [HttpPost]
        public ActionResult Edit(FileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var loginModel = (LoginModel)Session["LoginModelAdmin"];
                fileViewModel.CreatedBy = _userBusiness.getIdByUsername(loginModel.UserName);
                var fileDto = new FileDTO();
                fileDto.CreatedBy = fileViewModel.CreatedBy;
                fileDto.FileContent = fileViewModel.FileContent;
                fileDto.FileType = fileViewModel.FileType;
                fileDto.FilmID = fileViewModel.FilmID;
                fileDto.Tag = fileViewModel.Tag;
                var check = _fileBusiness.EditFile(fileDto);
                if (check == 1)
                {
                    return RedirectToAction("Index", "File");
                }
                else
                {
                    ViewBag.Message = "File đã tồn tại";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Chỉnh sửa file thất bại";
            }
            return View(fileViewModel);
        }
    }
}