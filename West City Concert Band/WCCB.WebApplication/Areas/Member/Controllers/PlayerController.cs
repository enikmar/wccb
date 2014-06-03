using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Member.Controllers
{
    [Authorize(Roles = "PlayingMembers, Administrators")]
    public class PlayerController : ApplicationController
    {
        public ActionResult TechnicalNotes()
        {
            return View();
        }
        
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult PlayerList()
        {
            return View();
        }

        public ActionResult Resources()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
