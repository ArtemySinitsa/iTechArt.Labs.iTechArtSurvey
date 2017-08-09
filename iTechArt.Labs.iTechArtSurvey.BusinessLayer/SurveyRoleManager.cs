using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer
{
    public class SurveyRoleManager : RoleManager<IdentityRole>
    {
        public SurveyRoleManager(SurveyContext context) : base(new RoleStore<IdentityRole>(context))
        {

        }
    }
}
