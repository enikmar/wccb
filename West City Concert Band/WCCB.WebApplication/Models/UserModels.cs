using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCCB.Models;

namespace WCCB.WebApplication.Models
{
    public class UserCheckPasswordModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }

    public class UserDetailModel
    {
        public User User { get; set; }
        public bool IsAdministrator { get; set; }
    }
}