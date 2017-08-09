using System.Security.Claims;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using Microsoft.AspNet.Identity;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer
{
    public static class UserIdentity
    {
        public static Task<ClaimsIdentity> GenerateUserIdentityAsync(this User user, SurveyUserManager manager)
        {
            return manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
