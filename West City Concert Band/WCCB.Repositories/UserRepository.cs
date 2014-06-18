using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using WCCB.Models;
using WCCB.DbContexts;
using WCCB.Repositories.Interfaces;

namespace WCCB.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public bool CheckPassword(Guid id, string password)
        {
            var user = FindById(id);
            var hashedPassword = user.Password;
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }

        public void ChangePassword(Guid id, string password)
        {
            var user = FindById(id);
            user.Password = Crypto.HashPassword(password);
            Update(user);
        }

        public override User Create(User item)
        {
            var user = new User
                {
                    Username = item.Username,
                    UserProfile = item.UserProfile,
                    Created = DateTime.Now,
                    Password = Crypto.HashPassword(item.Password),
                };

            Context.Users.Add(user);

            //assign roles to user
            foreach (var dbRole in item.Roles.Select(role => Context.Roles.First(x => x.RoleId == role.RoleId)))
            {
                user.Roles.Add(dbRole);
            }
            Context.SaveChanges();
            return user;
        }

        public override void Update(User item)
        {
            var user = FindById(item.UserId);
            user.Username = item.Username;
            user.Updated = DateTime.Now;
            user.UserProfile.Firstname = item.UserProfile.Firstname;
            user.UserProfile.Lastname = item.UserProfile.Lastname;
            user.UserProfile.Email = item.UserProfile.Email;
            user.UserProfile.PhoneNumber = item.UserProfile.PhoneNumber;
            user.UserProfile.MobileNumber = item.UserProfile.MobileNumber;
            user.UserProfile.Address1 = item.UserProfile.Address1;
            user.UserProfile.Address2 = item.UserProfile.Address2;
            user.UserProfile.Suburb = item.UserProfile.Suburb;
            user.UserProfile.ImgagePath = item.UserProfile.ImgagePath;
            user.UserProfile.PreferredContactType = item.UserProfile.PreferredContactType;
            user.Roles.Clear();

            Context.Users.Attach(user);
            Context.Entry(user).State = EntityState.Modified;

            //assign roles to user
            foreach (var dbRole in item.Roles.Select(role => Context.Roles.First(x => x.RoleId == role.RoleId)))
            {
                user.Roles.Add(dbRole);
            }
            Context.SaveChanges();
        }
        
    }
}
