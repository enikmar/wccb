using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCB.Models;

namespace WCCB.DataLayer
{
    public class WccbContext : DbContext
    {
        public WccbContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
