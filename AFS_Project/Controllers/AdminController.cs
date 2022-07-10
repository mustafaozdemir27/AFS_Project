using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFS_Project.Controllers
{
    public class AdminController : Controller
    {
        ISearchLogService _searchLogService;

        public AdminController(ISearchLogService searchLogService)
        {
            _searchLogService = searchLogService;
        }


        // GET: Admin
     
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSearchLogs()
        {
            var result = _searchLogService.GetAll();
            if (result.Success)
            {
                return Json(result.Data,JsonRequestBehavior.AllowGet);
            }

            return Json("Hata",JsonRequestBehavior.DenyGet);
        }
    }
}
