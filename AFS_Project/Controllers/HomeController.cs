using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFS_Project.Controllers
{
    public class HomeController : Controller
    {
        ISearchLogService _searchLogService;

        public HomeController(ISearchLogService searchLogService)
        {
            _searchLogService = searchLogService;
        }

        public ActionResult Index()
        {
            var result = _searchLogService.GetAll();
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}