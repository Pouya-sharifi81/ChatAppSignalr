using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilitiy
{
    public static class UserUtil
    {
        public static long GetUserId(this ClaimsPrincipal ? claim)
        {
            var userId = claim.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt64(userId);
        }
        public static string GetUserName(this ClaimsPrincipal? claim)
        {
            var userName = claim.FindFirst(ClaimTypes.Name).Value;
            return userName;
        }
    }
}
