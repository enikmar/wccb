using System.Data.Entity;
using WCCB.Models;

namespace WCCB.DbContexts
{
    public class WccbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Player> Players { get; set; }

        public WccbContext()
            : base("DefaultConnection")
        {
            
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasMany(u => u.Roles).
                WithMany(r => r.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RolesId");
                        m.ToTable("wccb_UserRoles");
                    });

        }
    }
}
