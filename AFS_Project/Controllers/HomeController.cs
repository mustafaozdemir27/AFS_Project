using Business.Abstract;
using DataAccess.Services.FunTranslationService.Common;
using DataAccess.Services.FunTranslationService.Interfaces;
using DataAccess.Services.FunTranslationService.Models;
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
        IFunTranslationService _funTranslationService;

        public HomeController(ISearchLogService searchLogService, IFunTranslationService funTranslationService)
        {
            _searchLogService = searchLogService;
            _funTranslationService = funTranslationService;
        }

        public ActionResult Index()
        {
            var result = _searchLogService.GetAll();
            var returnModel = new FunTranslationService();
            var serviceResult = _funTranslationService.GetResponse(new RequestModel { Text = "Merhaba televole" });
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

    }
}