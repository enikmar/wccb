using System.Web.Mvc;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class PlayerController : ApplicationController
    {
        private readonly IPlayerRepository _playerRepository;

        #region Constructors

        public PlayerController()
        {
            _playerRepository = new PlayerRepository();
        }

        #endregion

        #region Index

        public ActionResult Index()
        {
            return View(_playerRepository.FindAll());
        }
        
        #endregion

        #region Details
		
        public ActionResult Details(long id)
        {
            var player = _playerRepository.FindById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }
 
	    #endregion

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerRepository.Create(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        #endregion

        #region Edit

        public ActionResult Edit(long id)
        {
            var player = _playerRepository.FindById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerRepository.Update(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        #endregion

        #region Delete

        public ActionResult Delete(long id)
        {
            var player = _playerRepository.FindById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            return RedirectToAction("Delete", new { id });
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            _playerRepository.Dispose();
            base.Dispose(disposing);
        }

        #endregion

    }
}