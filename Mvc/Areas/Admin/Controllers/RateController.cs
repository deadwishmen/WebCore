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
    public class RateController : BaseController
    {
        private readonly IRateBusiness _rateBusiness;
        public RateController(IRateBusiness rateBusiness)
        {
            _rateBusiness = rateBusiness;
        }
        // GET: Admin/Rate
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            try
            {
                long total = 0;
                var model = _rateBusiness.GetListPage(ref total, page, pageSize);
                var pagination = new PaginationModel();
                var rateViewModel = new List<RateViewModel>();
                foreach (var item in model)
                {
                    rateViewModel.Add(new RateViewModel()
                    {
                        CreatedDate = item.CreatedDate,
                        UserID = item.UserID,
                        FilmID = item.FilmID,
                        ID = item.ID
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
                return View(rateViewModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            try
            {
                _rateBusiness.DeleteRate(id);
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
    }
}