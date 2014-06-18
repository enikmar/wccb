using System.Collections.Generic;
using System.Linq;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public bool IsUserInRole(string username, string roleName)
        {
            var role = GetRoleByRoleName(roleName);
            return role.Users.Select(x => x.Username).Contains(username);
        }

        public ICollection<Role> GetRolesForUser(string username)
        {
            return FindBy(x => x.Users.Select(y => y.Username).Contains(username)).ToList();
        }

        public Role GetRoleByRoleName(string roleName)
        {
            var roles = FindBy(x => x.Name == roleName).ToList();
            return roles.Any() ? roles.First() : null;
        }
    }
}
