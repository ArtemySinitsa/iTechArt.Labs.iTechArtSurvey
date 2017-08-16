using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
