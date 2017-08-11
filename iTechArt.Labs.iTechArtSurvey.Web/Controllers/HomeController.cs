using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Great discription.";

            return View();
        }
    }
}