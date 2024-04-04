using System.Security.Claims;
using static MountainTrailsSystem.Core.Constants.RoleConstants;

namespace MountainTrailsSystem.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdministratorRole);
        }
    }
}
