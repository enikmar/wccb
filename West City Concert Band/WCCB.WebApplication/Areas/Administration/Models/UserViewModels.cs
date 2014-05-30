using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCCB.Models;
using WCCB.WebApplication.Models.Shared;

namespace WCCB.WebApplication.Areas.Administration.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<Role> Roles { get; set; } 
    }

    public class UserCreateViewModel
    {
        public User User { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<CheckBoxListItem> Roles { get; set; }
    }


}