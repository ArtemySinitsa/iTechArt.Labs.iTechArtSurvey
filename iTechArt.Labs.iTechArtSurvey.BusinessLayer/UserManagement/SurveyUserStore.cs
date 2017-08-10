using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer
{
    public class SurveyUserStore : UserStore<User>
    {
        public SurveyUserStore(DbContext context) : base(context)
        {
        }

        public static SurveyUserStore Create(IOwinContext context)
        {
            return new SurveyUserStore(context.Get<SurveyContext>());
        }
    }
}
