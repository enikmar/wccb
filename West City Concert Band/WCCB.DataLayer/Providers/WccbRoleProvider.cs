using System;
using System.Linq;
using System.Web.Security;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Repositories;
using WCCB.DataLayer.Repositories.Interfaces;

namespace WCCB.DataLayer.Providers
{
    /* 
     * Custom Role Provider:
     * Methods needed to be overriden - IsUserInRole(), GetRolesForUser()
     */
    public class WccbRoleProvider : RoleProvider
    {
        private readonly IRoleRepository _roleRepository;

        #region Constructors

        public WccbRoleProvider()
        {
            _roleRepository = new RoleRepository();
        }

        public WccbRoleProvider(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion

        public override bool IsUserInRole(string username, string roleName)
        {
            return _roleRepository.IsUserInRole(username, roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            return _roleRepository.GetRolesForUser(username).Select(x => x.Name).ToArray();
        }
        
        #region Overrides of RoleProvider

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion
    }
}
