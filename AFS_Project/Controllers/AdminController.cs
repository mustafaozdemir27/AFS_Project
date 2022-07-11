using Business.Abstract;
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


        public ActionResult Index()
        {
            if (Session["userRole"] != null && Session["userRole"].ToString() == "Admin")
            {
                ViewBag.UserName = Session["UserName"];
                return View();
            }
            return Redirect("/Error/Index");
        }

        public JsonResult GetSearchLogs()
        {
            var result = _searchLogService.GetAll();
            if (result.Success)
            {
                return Json(result.Data, JsonRequestBehavior.AllowGet);
            }

            return Json("Hata", JsonRequestBehavior.DenyGet);
        }
    }
}
