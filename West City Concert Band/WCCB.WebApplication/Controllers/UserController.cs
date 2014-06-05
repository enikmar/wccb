using System;
using System.Web.Helpers;
using System.Web.Mvc;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Providers;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.WebApplication.Models;
using WebMatrix.WebData;

namespace WCCB.WebApplication.Controllers
{
    public class UserController : ApplicationController
    {
        private readonly IUserRepository _userRepository;

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        #endregion

        #region Login

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(model.UserName, model.Password))
                    return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        #endregion

        #region Logoff


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Details

        [Authorize]
        public ActionResult Detail(Guid id)
        {
            var user = _userRepository.FindById(id);
            return View(user);
        }

        #endregion

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}