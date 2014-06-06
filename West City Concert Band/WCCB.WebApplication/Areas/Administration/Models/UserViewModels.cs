using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }

    public class UserCreateViewModel
    {
        public User User { get; set; }

        public IEnumerable<CheckBoxListItem> Roles { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } //needed to do front end compare and validate on server

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class UserEditViewModel
    {
        public User User { get; set; }
        public IEnumerable<CheckBoxListItem> Roles { get; set; } 
    }

    public class UserGridModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
    }

}