using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCCB.WebApplication.Controllers
{
    public class HomeController : ApplicationController
    {
        #region Home Page

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region About Menu

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult MusicalDirector()
        {
            return View();
        }

        public ActionResult Players()
        {
            return View();
        }

        public ActionResult Committee()
        {
            return View();
        }

        public ActionResult Constitution()
        {
            return View();
        }

        #endregion

        #region Youth Menu

        public ActionResult Youth()
        {
            return View();
        }
        
        #endregion

        #region Events Menu

        public ActionResult Events()
        {
            return View();
        }

        #endregion

        #region News Menu

        public ActionResult News()
        {
            return View();
        }
        
        #endregion

        #region Gallery Menu

        public ActionResult Gallery()
        {
            return View();
        }
        
        #endregion

        #region Contact Menu

        public ActionResult Contact()
        {
            return View();
        }
        
        #endregion
    }
}
