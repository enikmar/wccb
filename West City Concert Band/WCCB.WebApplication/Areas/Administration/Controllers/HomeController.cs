using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View("~/Areas/Administration/Views/Home/Index.cshtml");
        }

    }
}
