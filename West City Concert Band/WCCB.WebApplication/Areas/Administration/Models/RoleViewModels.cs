using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCCB.Models;

namespace WCCB.WebApplication.Areas.Administration.Models
{
    public class RoleGridModel
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public int UserCount { get; set; }
    }

}