using System.Web.Http;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.Config;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(iTechArt.Labs.iTechArtSurvey.Web.Startup))]
namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OwinConfiguration.RegisterManagers(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            var config = new HttpConfiguration();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            app.UseWebApi(config);
        }
    }
}
