using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCB.Models
{
    [Table("wccb_Players")]
    public class Player
    {
        public long PlayerId { get; set; }
        public Guid UserId { get; set; }
        public string Instrument { get; set; }
        public int? Part { get; set; }
        public string Section { get; set; }
        public bool IsLeader { get; set; }
        public bool IsActive { get; set; }
    }
}
