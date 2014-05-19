using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(WccbContext context) : base(context)
        {
        }

        public bool CheckPassword(Guid id, string password)
        {
            var user = GetById(id);
            var hashedPassword = user.Password;
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }

        public User GetUserByUsername(string username)
        {
            var users = Get(user => user.Username == username).ToList();
            return users.Any() ? users.First() : null;
        }
    }
}
