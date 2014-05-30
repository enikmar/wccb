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

        #region About

        public ActionResult About()
        {
            return View();
        }

        #endregion

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
