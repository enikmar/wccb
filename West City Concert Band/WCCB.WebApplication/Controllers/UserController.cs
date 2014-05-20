using System;
using System.Web.Helpers;
using System.Web.Mvc;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Providers;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.WebApplication.Models;

namespace WCCB.WebApplication.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly WccbMembershipProvider _membershipProvider;
        private readonly WccbRoleProvider _roleProvider;

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository(new WccbContext());
            _membershipProvider = new WccbMembershipProvider();
            _roleProvider = new WccbRoleProvider();
        }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _membershipProvider = new WccbMembershipProvider();
            _roleProvider = new WccbRoleProvider();
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
                user.UserId = Guid.NewGuid();
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
        
        #region Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(_membershipProvider.ValidateUser(model.UserName, model.Password))
                    return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
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