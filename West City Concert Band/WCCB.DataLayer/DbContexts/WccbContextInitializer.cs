using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using WCCB.Helpers;
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

#if true
            var roleAdministrators = new Role {Name = Enumerations.RoleTypes.Administrators.ToString()};
            var roleCommiteeMembers = new Role { Name = Enumerations.RoleTypes.CommitteeMembers.ToString() };
            var roleMembers = new Role { Name = Enumerations.RoleTypes.Members.ToString() };
            var rolePlayers = new Role { Name = Enumerations.RoleTypes.Players.ToString() };
            var roleSupporters = new Role { Name = Enumerations.RoleTypes.Supporters.ToString() };
            context.Roles.Add(roleAdministrators);
            context.Roles.Add(roleCommiteeMembers);
            context.Roles.Add(roleMembers);
            context.Roles.Add(rolePlayers);
            context.Roles.Add(roleSupporters);
            //context.SaveChanges();

            context.Users.Add(new User
                                  {
                                      Username = "lamara",
                                      Password = Crypto.HashPassword("lamara"),
                                      Roles = { roleAdministrators, roleMembers, rolePlayers },
                                      UserProfile = new UserProfile
                                                        {
                                                            Firstname = "Lamar",
                                                            Lastname = "Ah-Chee",
                                                            Email = "lamara@westcityband.org"
                                                        }
                                  });
            context.Users.Add(new User
                                  {
                                      Username = "benh",
                                      Password = Crypto.HashPassword("benh"),
                                      Roles = { roleMembers, rolePlayers },
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
