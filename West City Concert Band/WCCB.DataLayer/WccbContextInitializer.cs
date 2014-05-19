using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Helpers;
using System.Web.Security;
using WCCB.Models;
using WebMatrix.WebData;

namespace WCCB.DataLayer
{
    public class WccbContextInitializer : DropCreateDatabaseAlways<WccbContext>
    {
        public WccbContextInitializer()
        {
            this.Seed(new WccbContext());
        }

        protected override void Seed(WccbContext context)
        {
            var roleAdmin = context.Roles.Add(new Role {Name = "Admin"});
            var roleMember = context.Roles.Add(new Role {Name = "Member"});
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
