using iTechArt.Labs.iTechArtSurvey.BusinessLayer.SurveyManagement;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Owin;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Config
{
    public static class OwinConfiguration
    {
        public static void RegisterManagers(IAppBuilder app)
        {
            app.CreatePerOwinContext(SurveyContext.Create);
            app.CreatePerOwinContext<SurveyUserManager>(SurveyUserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);
            app.CreatePerOwinContext<SurveyRoleManager>(SurveyRoleManager.Create);
            app.CreatePerOwinContext<SurveyManager>(SurveyManager.Create);
        }

    }
}
