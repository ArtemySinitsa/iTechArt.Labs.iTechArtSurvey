using System.Web.Optimization;

namespace iTechArt.Labs.iTechArtSurvey.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/about").Include(
                    "~/Scripts/require.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/tether.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/survey-react").Include(
                      "~/Scripts/react/main.js",
                      "~/Scripts/react/service-worker.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css"));
        }
    }
}
