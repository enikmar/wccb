using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCCB.Models
{
    [Table("wccb_Users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; } 

        public User()
        {
            Roles = new HashSet<Role>();
        }
    }
}
