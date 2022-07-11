using AFS_Project.Repositories.Abstract;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFS_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionRepository _sessionRepository;

        public AccountController(IUserService userService, ISessionRepository sessionRepository)
        {
            _userService = userService;
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Get(username, password);
                if (user.Success)
                {
                    switch (user.Data.UserRole.RoleName)
                    {
                        case "Admin":
                            _sessionRepository.AddSession(user.Data.UserName, user.Data.UserRole.RoleName);
                            return Redirect("/Admin/Index");

                        case "StandartUser":
                            _sessionRepository.AddSession(user.Data.UserName, user.Data.UserRole.RoleName);
                            return Redirect("/Home/Index");
                        default :
                            return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
    }
}