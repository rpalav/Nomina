using System.IdentityModel.Tokens.Jwt;

namespace APINomina.Util
{
    public class ClaimsUser
    {
        public static int GetIdUser(HttpContext context) {
            var user = context.User;
            
            if (user.Identity.IsAuthenticated)
            {
                var claimValue = user.Claims.FirstOrDefault().Value;
                return Convert.ToInt32(claimValue);
            }
            return 0;
        }
    }
}
