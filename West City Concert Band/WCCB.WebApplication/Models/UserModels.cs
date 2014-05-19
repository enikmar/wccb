using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCCB.WebApplication.Models
{
    public class UserCheckPasswordModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}