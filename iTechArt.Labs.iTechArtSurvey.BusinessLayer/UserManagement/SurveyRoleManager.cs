using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement
{
    public class SurveyRoleManager : RoleManager<IdentityRole>
    {
        public SurveyRoleManager(SurveyContext context) : base(new RoleStore<IdentityRole>(context))
        {
        }

        public static SurveyRoleManager Create(
            IdentityFactoryOptions<SurveyRoleManager> options,
            IOwinContext context)
        {
            return new SurveyRoleManager(context.Get<SurveyContext>());
        }
    }
}
