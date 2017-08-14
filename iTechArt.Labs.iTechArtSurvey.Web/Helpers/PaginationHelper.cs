using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.Helpers
{
    public static class PaginationHelper
    {
        public static MvcHtmlString Pagination(this HtmlHelper html, int page, int count, int pageSize)
        {

            string controller = html.ViewContext.RouteData.Values["controller"].ToString();
            string action = html.ViewContext.RouteData.Values["action"].ToString();
            var urls = new UrlHelper(html.ViewContext.RequestContext);
            var pages = new TagBuilder("ul");
            pages.AddCssClass("pagination justify-content-end col");

            var leftDouble = BuildLink(urls, "fa fa-angle-double-left fa page-link", 1);

            var leftSingle = BuildLink(urls, "fa fa-angle-left fa page-link", page - 1);

            var rightSingle = BuildLink(urls, "fa fa-angle-right fa page-link", page + 1);

            var rightDouble = BuildLink(urls, "fa fa-angle-double-right fa page-link", (count / pageSize) + (count % pageSize));

            var summary = new TagBuilder("h4");
            summary.SetInnerText("Summary: " + count);
            summary.AddCssClass("col");

            var container = new TagBuilder("div");
            container.AddCssClass("row");
            container.InnerHtml += summary.ToString();

            pages.InnerHtml += WrapAngle(leftDouble, page <= 1);
            pages.InnerHtml += WrapAngle(leftSingle, page <= 1);
            pages.InnerHtml += WrapAngle(rightSingle, (page * pageSize) >= count);
            pages.InnerHtml += WrapAngle(rightDouble, (page * pageSize) >= count);

            container.InnerHtml += pages.ToString();

            return new MvcHtmlString(container.ToString());
        }
        private static TagBuilder BuildLink(UrlHelper urlHelper, string classes, int parameter)
        {
            var link = new TagBuilder("a");
            link.AddCssClass(classes);
            link.Attributes.Add("href", urlHelper.RouteUrl(new { page = parameter }));
            return link;
        }
        private static string WrapAngle(TagBuilder tag, bool disabled)
        {
            var angleWrapper = new TagBuilder("li");
            angleWrapper.AddCssClass("page-item");
            if (disabled)
            {
                angleWrapper.AddCssClass("disabled");
            }
            angleWrapper.InnerHtml = tag.ToString();
            return angleWrapper.ToString();
        }
    }
}