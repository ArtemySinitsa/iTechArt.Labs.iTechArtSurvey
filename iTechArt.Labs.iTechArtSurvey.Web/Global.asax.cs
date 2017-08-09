using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using iTechArt.Labs.iTechArtSurvey.Web.Models;

namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new SurveyContextInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var db = new SurveyContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}
