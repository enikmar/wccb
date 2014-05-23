using System;
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
            var user = FindById(item.UserId);
            user.Username = item.Username;
            user.Password = Crypto.HashPassword(item.Password);
            return base.Create(item);
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
