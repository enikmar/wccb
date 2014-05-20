using System.Data.Entity;
using System.Web.Helpers;
using WCCB.Models;

namespace WCCB.DataLayer.DbContexts
{
    public class WccbContextInitializer : DropCreateDatabaseAlways<WccbContext>
    {
        public WccbContextInitializer()
        {
            this.Seed(new WccbContext());
        }

        protected override void Seed(WccbContext context)
        {
            var roleAdmin = context.Roles.Add(new Role {Name = "Administrators"});
            var roleMember = context.Roles.Add(new Role {Name = "Members"});
            context.SaveChanges();

            context.Users.Add(new User
                                  {
                                      Username = "Administrator",
                                      Password = Crypto.HashPassword("!3joe37T"),
                                      Roles = {roleAdmin, roleMember}
                                  });
            context.Users.Add(new User
                                  {
                                      Username = "Member",
                                      Password = Crypto.HashPassword("abc123"),
                                      Roles = {roleMember}
                                  });

            context.SaveChanges();
        }
    }
}
