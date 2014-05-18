using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace WCCB.Models
{
    [Table("wccb.Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(450)]
        [Index("UsernameIndex", IsUnique = true)]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
