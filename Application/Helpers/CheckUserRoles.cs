using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class CheckUserRoles
    {

        public static bool IsManagmentUser(Users user)
        {
                if (new[] { RolesEnum.Admin, RolesEnum.Manager, RolesEnum.SuperAdmin }.Contains(user.RoleId))
                    return true;
            return false;
        }
        public static bool IsAdminUser(Users user)
        {
                if (new[] { RolesEnum.Admin, RolesEnum.SuperAdmin }.Contains(user.RoleId))
                return true;
            return false;
        }

        public static bool CanCurrentUserUpdate(ClaimsIdentity userIdentity, Users existingUser, Users modifiedUser = null)
        {
            string claimRole = userIdentity.Claims.SingleOrDefault(x => x.Type.EndsWith("/identity/claims/role")).Value;

            if (String.IsNullOrEmpty(claimRole))
                throw new Exception("Role not found");

            RolesEnum enumRole = (RolesEnum)Enum.Parse(typeof(RolesEnum), claimRole, true);
            if (existingUser.UserName == userIdentity.Name && modifiedUser == null)
                return true;
            else
            {
                bool result = enumRole < existingUser.RoleId;
                if (result && modifiedUser != null)
                    result = enumRole < modifiedUser.RoleId;
                return result;
            }
                 
        }

        public static bool HasCurrentUserHigherRole(ClaimsIdentity userIdentity, RolesEnum role)
        {
            string claimRole = userIdentity.Claims.SingleOrDefault(x => x.Type.EndsWith("/identity/claims/role")).Value;

            if (String.IsNullOrEmpty(claimRole))
                throw new Exception("Role not found");

            RolesEnum enumRole = (RolesEnum)Enum.Parse(typeof(RolesEnum), claimRole, true);
            return enumRole < role;

        }
    }
}
