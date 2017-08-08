using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iTechArt.Labs.iTechArtSurvey.Web.Startup))]
namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
