using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using WCCB.Helpers;
using WCCB.Models;

namespace WCCB.DbContexts
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
            var rolePlayingMembers = new Role { Name = Enumerations.RoleTypes.PlayingMembers.ToString() };
            var roleNonPlayingMembers = new Role { Name = Enumerations.RoleTypes.NonPlayingMembers.ToString() };
            var roleLifeMembers = new Role { Name = Enumerations.RoleTypes.LifeMembers.ToString() };
            context.Roles.Add(roleAdministrators);
            context.Roles.Add(roleCommiteeMembers);
            context.Roles.Add(rolePlayingMembers);
            context.Roles.Add(roleNonPlayingMembers);
            context.Roles.Add(roleLifeMembers);
            //context.SaveChanges();

            context.Users.Add(new User
                                  {
                                      Username = "lamara",
                                      Password = Crypto.HashPassword("lamara"),
                                      Roles = { roleAdministrators, rolePlayingMembers },
                                      UserProfile = new UserProfile
                                                        {
                                                            Firstname = "Lamar",
                                                            Lastname = "Ah-Chee",
                                                            Email = "lamara@westcityband.org",
                                                            Gender = Enumerations.GenderTypes.Male.ToString()
                                                        }
                                  });
            context.Users.Add(new User
                                  {
                                      Username = "benh",
                                      Password = Crypto.HashPassword("benh"),
                                      Roles = { rolePlayingMembers },
                                      UserProfile = new UserProfile
                                                        {
                                                            Firstname = "Ben",
                                                            Lastname = "Harrington",
                                                            Email = "benh@westcityband.org",
                                                            Gender = Enumerations.GenderTypes.Male.ToString()
                                                        },
                                  });

            context.SaveChanges();
            context.Dispose();
#endif
        }
    }
}
