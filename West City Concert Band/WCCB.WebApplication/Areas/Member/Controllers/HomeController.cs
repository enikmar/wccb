using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.Helpers;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Member.Controllers
{
    [Authorize(Roles = "Members, Administrators")]
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View("~/Areas/Member/Views/Home/Home.cshtml");
        }

        public ActionResult Notices()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

    }
}
