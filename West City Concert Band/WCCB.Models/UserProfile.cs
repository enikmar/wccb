using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCB.Helpers;

namespace WCCB.Models
{
    [Table("wccb_UserProfile")]
    public class UserProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserProfileId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Suburb { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string PreferredContactType { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImgagePath { get; set; }
    }
}
