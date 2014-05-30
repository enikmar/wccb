using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using WCCB.Models;

namespace WCCB.DataLayer.DbContexts
{
    public class WccbContextInitializer : DropCreateDatabaseIfModelChanges<WccbContext>
    {
        public WccbContextInitializer()
        {
            Seed(new WccbContext());
        }

        protected override sealed void Seed(WccbContext context)
        {

#if false
		
            var roleAdmin = context.Roles.Add(new Role { Name = "Administrators" });
            var roleMember = context.Roles.Add(new Role { Name = "Members" });
            context.SaveChanges();

            context.Users.Add(new User
                                  {
                                      Username = "lamara",
                                      Password = Crypto.HashPassword("!3joe37T"),
                                      Roles = { roleAdmin, roleMember },
                                      UserProfile = new UserProfile
                                                        {
                                                            Firstname = "Lamar",
                                                            Lastname = "Ah-chee",
                                                            Email = "lamara@westcityband.org"
                                                        }
                                  });
            context.Users.Add(new User
                                  {
                                      Username = "benh",
                                      Password = Crypto.HashPassword("benh"),
                                      Roles = { roleMember },
                                      UserProfile = new UserProfile
                                                        {
                                                            Firstname = "Ben",
                                                            Lastname = "Harrington",
                                                            Email = "benh@westcityband.org"
                                                        },
                                  });

            context.SaveChanges();
            context.Dispose();
#endif
        }
    }
}
