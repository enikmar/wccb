using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories
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
            user.Password = Crypto.HashPassword(item.Password);
            base.Update(item);
        }
        
    }
}
