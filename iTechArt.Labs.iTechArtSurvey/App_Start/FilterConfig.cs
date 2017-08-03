using System.Web;
using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
