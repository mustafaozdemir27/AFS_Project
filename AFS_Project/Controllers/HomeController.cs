using AFS_Project.Models;
using Business.Abstract;
using DataAccess.Services.FunTranslationService.Common;
using DataAccess.Services.FunTranslationService.Interfaces;
using DataAccess.Services.FunTranslationService.Models;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFS_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFunTranslationService _funTranslationService;
        private readonly ISearchLogService _searchLogService;
   

        public HomeController(IFunTranslationService funTranslationService, ISearchLogService searchLogService)
        {
            _funTranslationService = funTranslationService;
            _searchLogService = searchLogService;
        }

        public ActionResult Index(Translate model)
        {
            if (Session["userRole"] != null && Session["userRole"].ToString() == "StandartUser")
            {
                ViewBag.UserName = Session["UserName"];
                return View(model);
            }
            return Redirect("/Error/Index");
        }
        [HttpPost]
        public ActionResult Translate(string inputText)
        {
            var model = new Translate();
            var translationResult = _funTranslationService.GetResponse(new RequestModel { Text = inputText });
            if (!string.IsNullOrWhiteSpace(translationResult.Contents.Translated))
            {
                var logResult = _searchLogService.Add(new SearchLog
                {
                    CreatedDate = DateTime.Now.ToString(),
                    InputText = inputText,
                    TranslatedText = translationResult.Contents.Translated,
                    TranslationType = translationResult.Contents.Translation,
                    UserName = Session["UserName"].ToString()

                });
                if (logResult.Success)
                {
                    model.InputText = translationResult.Contents.Text;
                    model.TranslatedText = translationResult.Contents.Translated;
                    return RedirectToAction("Index", model);
                }

            }
            return View();
        }
    }
}