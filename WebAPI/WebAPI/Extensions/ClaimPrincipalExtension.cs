using Backend.Common.Constants;
using Backend.Common.Enums;
using System.Security.Claims;

namespace WebAPI.Extensions
{
    public static class ClaimPrincipalExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypeConstants.UserId || x.Type == ClaimsIdentity.DefaultNameClaimType);
            if(claim == null) return Guid.Empty;
            return Guid.Parse(claim.Value);
        }

        public static List<string> GetRoles(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            if(claim == null) return new List<string>();
            return claim.Value.Split(",").ToList<string>();
        }

        public static bool IsAdmin(this ClaimsPrincipal claimsPrincipal)
        {
            var roles = GetRoles(claimsPrincipal);
            return roles.Contains(RoleTypeEnum.Admin.ToString());
        }
    }
}
