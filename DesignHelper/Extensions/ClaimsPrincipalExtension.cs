using System.Security.Claims;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;
using static DesignHelper.Areas.Moderator.Constrains.ModeratorConstrains;
using static DesignHelper.Areas.User.Constrains.UserConstrains;

namespace DesignHelper.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
        public static bool IsModerator(this ClaimsPrincipal user)
        {
            return user.IsInRole(ModeratorRoleName);
        }
        public static bool IsUser(this ClaimsPrincipal user)
        {
            return user.IsInRole(UserRoleName);
        }
    }
}
