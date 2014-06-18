using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        bool IsUserInRole(string username, string roleName);
        ICollection<Role> GetRolesForUser(string username);
        Role GetRoleByRoleName(string roleName);
    }
}
