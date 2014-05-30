using System;
using System.Linq;
using System.Web.Mvc;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.WebApplication.Areas.Administration.Models;
using WCCB.WebApplication.Controllers;
using WCCB.WebApplication.Models.Shared;

namespace WCCB.WebApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UserController : ApplicationController
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
        }

        #endregion

        #region Index

        public ActionResult Index()
        {
            var model = _userRepository.FindAll().ToList().Select(x => new UserViewModel
                                                                           {
                                                                               User = x,
                                                                               UserProfile = x.UserProfile,
                                                                               //Roles = x.Roles
                                                                           });
            return View(model);
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
            var model = new UserCreateViewModel
                            {
                                User = new User(),
                                UserProfile = new UserProfile(),
                                Roles = _roleRepository.FindAll().Select(x => new CheckBoxListItem
                                                                                  {
                                                                                      Text = x.Name,
                                                                                      Value = Convert.ToString(x.RoleId),
                                                                                      Selected = false
                                                                                  })
                            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User.UserProfile = model.UserProfile;
                _userRepository.Create(model.User);
                return RedirectToAction("Index");
            }

            return View(model);
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