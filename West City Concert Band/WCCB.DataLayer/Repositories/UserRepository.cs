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
        #region Constructors

        public UserRepository(WccbContext context) : base(context)
        {
        }

        #endregion

        public bool CheckPassword(Guid id, string password)
        {
            var user = GetById(id);
            var hashedPassword = user.Password;
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }

        public void UpdatePassword(Guid id, string password)
        {
            var user = GetById(id);
            user.Password = Crypto.HashPassword(password);
            Update(user);
        }

        public User GetUserByUsername(string username)
        {
            var users = Get(user => user.Username == username).ToList();
            return users.Any() ? users.First() : null;
        }
    }
}
