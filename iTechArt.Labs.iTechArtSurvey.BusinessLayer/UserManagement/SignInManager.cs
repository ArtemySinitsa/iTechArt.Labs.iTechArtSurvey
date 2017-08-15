using System.Security.Claims;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement
{
    public class SignInManager : SignInManager<User, string>
    {
        public SignInManager(SurveyUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            var userIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("SurveyContext:Name", user.Name));

            return userIdentity;
        }

        public async Task<bool> IsEmailConfirmed(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            return user.EmailConfirmed;
        }
        public static SignInManager Create(
            IdentityFactoryOptions<SignInManager> options,
            IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<SurveyUserManager>(), context.Authentication);
        }
    }
}
