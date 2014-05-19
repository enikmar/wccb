using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.DataLayer;
using WCCB.WebApplication.Models;

namespace WCCB.WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository(new WccbContext());
        }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Index

        [HttpGet]
        public ActionResult Index()
        {
            return View(_userRepository.GetAll());
        }

        #endregion

        #region Details

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        #endregion

        #region Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                user.Password = Crypto.HashPassword(user.Password);
                _userRepository.Create(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        #endregion

        #region Edit

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        #endregion

        #region Delete

        public ActionResult Delete(Guid id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        #endregion

        #region CheckPassword

        [HttpGet]
        public ActionResult CheckPassword(Guid id)
        {
            var model = new UserCheckPasswordModel
                            {
                                Id = id,
                            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckPassword(UserCheckPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var isValid = _userRepository.CheckPassword(model.Id, model.Password);
                if (isValid)
                    ViewBag.Message = "Password Matches";
                else
                    ViewBag.Message = "NO";
            }
            return View(model);
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            _userRepository.Dispose();
            base.Dispose(disposing);
        }

        #endregion

    }
}