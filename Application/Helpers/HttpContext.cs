using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace System.Web
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _contextAccessor;


        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;


        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public static bool CanCurrentUserUpdate(ClaimsIdentity userIdentity, User existingUser, User modifiedUser = null)
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

        public static bool IsCurrentUserAdmin()
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).FirstOrDefault();
            if (role == "Admin" || role == "SuperAdmin")
                return true;
            return false;
        }

        public static int GetUserId()
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).FirstOrDefault();

            return int.Parse(userId);
        }


    }
}
