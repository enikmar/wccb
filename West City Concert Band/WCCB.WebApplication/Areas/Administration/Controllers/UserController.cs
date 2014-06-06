using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
            var model =
                _userRepository.FindAll().OrderBy(x => x.UserProfile.Firstname).ToList().Select(x => new UserViewModel
                    {
                        User = x,
                        //UserProfile = x.UserProfile,
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
                    Roles = _roleRepository.FindAll().ToList().Select(x => new CheckBoxListItem
                        {
                            Text = x.Name,
                            Value = Convert.ToString(x.RoleId),
                            Selected = false
                        }).ToList()
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roles = model.Roles.Where(x => x.Selected).Select(x => Convert.ToDouble(x.Value)).ToList();
                model.User.Password = model.Password;
                model.User.Roles = _roleRepository.FindBy(x => roles.Contains(x.RoleId)).ToList();
                _userRepository.Create(model.User);
                return RedirectToAction("Index");
            }
            model.Roles = _roleRepository.FindAll().ToList()
                                         .Select(x => new CheckBoxListItem
                                             {
                                                 Text = x.Name,
                                                 Value = Convert.ToString(x.RoleId),
                                                 Selected = false
                                             });
            return View(model);
        }

        #endregion

        #region Edit

        public ActionResult Edit(Guid id)
        {
            var user = _userRepository.FindById(id);
            var model = new UserEditViewModel
                {
                    User = user,
                    Roles = _roleRepository.FindAll().ToList().Select(x => new CheckBoxListItem
                        {
                            Text = x.Name,
                            Value = Convert.ToString(x.RoleId),
                            Selected = user.Roles.Select(y => y.RoleId).Contains(x.RoleId),
                        })
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roles = model.Roles.Where(x => x.Selected).Select(x => Convert.ToDouble(x.Value)).ToList();
                model.User.Roles = _roleRepository.FindBy(x => roles.Contains(x.RoleId)).ToList();
                _userRepository.Update(model.User);
                return RedirectToAction("Index");
            }
            var user = _userRepository.FindById(model.User.UserId);
            model.Roles = _roleRepository.FindAll().ToList().Select(x => new CheckBoxListItem
                {
                    Text = x.Name,
                    Value = Convert.ToString(x.RoleId),
                    Selected = user.Roles.Select(y => y.RoleId).Contains(x.RoleId),
                });
            return View(model);
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

        #region Kendo Ajax


        public ActionResult GetUsers([DataSourceRequest]DataSourceRequest request)
        {
            var users = _userRepository.FindAll().ToList();
            return Json(users.Select(_ToGridModel).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Helpers

        private UserGridModel _ToGridModel(User user)
        {
            return new UserGridModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Name = string.Format("{0} {1}", user.UserProfile.Firstname, user.UserProfile.Lastname),
                    Roles = string.Join("<br/>", user.Roles.Select(x => x.Name)),
                    ImagePath = user.UserProfile.ImgagePath
                };
        }

        #endregion
    }
}