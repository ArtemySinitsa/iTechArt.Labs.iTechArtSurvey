using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(SurveyContext.Create);
            app.CreatePerOwinContext<SurveyUserManager>(SurveyUserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);
            app.CreatePerOwinContext<SurveyRoleManager>(SurveyRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}