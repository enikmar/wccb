using System;
using System.Web.Mvc;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;

namespace WCCB.WebApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        #endregion

        #region Index

        public ActionResult Index()
        {
            return View(_userRepository.FindAll());
        }

        #endregion

        #region Details

        public ActionResult Details(Guid id)
        {
            var user = _userRepository.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        #endregion

        #region Edit

        public ActionResult Edit(Guid id)
        {
            var user = _userRepository.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
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
            _userRepository.Delete(id);
            return View();
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