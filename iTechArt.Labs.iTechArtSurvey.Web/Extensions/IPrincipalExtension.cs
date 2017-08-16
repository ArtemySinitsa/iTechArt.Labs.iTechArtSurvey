using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace iTechArt.Labs.iTechArtSurvey.Web.Extensions
{
    public static class IPrincipalExtension
    {
        public static string GetName(this IPrincipal principal)
        {
            var claimsPrincipal = principal as ClaimsPrincipal;

            var nameClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "SurveyContext:Name");
            if (nameClaim != null)
            {
                return nameClaim.Value;
            }

            return principal.Identity.Name;
        }
    }
}