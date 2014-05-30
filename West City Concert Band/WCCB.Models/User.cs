using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCCB.Models
{
    [Table("wccb_Users")]
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Created = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Created { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime? Updated { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
