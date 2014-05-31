using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.WebApplication.Controllers;

namespace WCCB.WebApplication.Areas.Member.Controllers
{
    public class PlayerController : ApplicationController
    {
        //
        // GET: /Member/Player/

        public ActionResult TechnicalNotes()
        {
            return View();
        }

    }
}
