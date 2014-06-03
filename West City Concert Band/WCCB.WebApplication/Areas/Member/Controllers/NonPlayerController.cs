using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCCB.WebApplication.Areas.Member.Controllers
{
    [Authorize(Roles = "NonPlayingMembers, Administrators")]
    public class NonPlayerController : Controller
    {
        public ActionResult Benefits()
        {
            return View();
        }

    }
}
