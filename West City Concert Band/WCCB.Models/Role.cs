using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCCB.Models
{
    [Table("wccb_Roles")]
    public class Role
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } 

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}
