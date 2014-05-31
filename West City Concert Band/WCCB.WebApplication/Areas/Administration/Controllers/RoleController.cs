using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.DataLayer.DbContexts;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RoleController : ApplicationController
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        #region Constructors

        public RoleController()
        {
            _roleRepository = new RoleRepository();
            _userRepository = new UserRepository();
        }
        
        #endregion

        #region Index

        public ActionResult Index()
        {
            return View(_roleRepository.FindAll());
        }
        
        #endregion

        #region Details

        public ActionResult Details(long id)
        {
            var role = _roleRepository.FindById(id);
            return View(role);
        }
        
        #endregion

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.Create(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        #endregion

        #region Edit

        public ActionResult Edit(long id)
        {
            var role = _roleRepository.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        #endregion

        #region Delete

        public ActionResult Delete(long id)
        {
            var role = _roleRepository.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            _roleRepository.Dispose();
            base.Dispose(disposing);
        }
        
        #endregion
    }
}