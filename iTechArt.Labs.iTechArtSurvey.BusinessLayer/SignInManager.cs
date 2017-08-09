using System.Security.Claims;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer
{
    public class SignInManager : SignInManager<User, string>
    {
        public SignInManager(SurveyUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((SurveyUserManager)UserManager);
        }

        public static SignInManager Create(
            IdentityFactoryOptions<SignInManager> options,
            IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<SurveyUserManager>(), context.Authentication);
        }
    }
}
