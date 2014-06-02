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

        #region About Section

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

        public ActionResult Contact()
        {
            return View();
        }
    }
}
