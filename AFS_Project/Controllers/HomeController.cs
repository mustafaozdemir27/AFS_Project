using AFS_Project.Models;
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
        IFunTranslationService _funTranslationService;

        public HomeController( IFunTranslationService funTranslationService)
        {
            _funTranslationService = funTranslationService;
        }

        public ActionResult Index(Translate model)
        {

            return View(model);
        }
        [HttpPost]
        public ActionResult Translate(string inputText)
        {
            var model = new Translate();
            var translationResult = _funTranslationService.GetResponse(new RequestModel { Text = inputText });
            if (!string.IsNullOrWhiteSpace(translationResult.Contents.Translated))
            {
                model.TranslatedText = "Mustafa";

                return RedirectToAction("Index", model);
            }
            return View();
        }
    }
}