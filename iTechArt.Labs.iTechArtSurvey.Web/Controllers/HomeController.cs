using System.Web.Mvc;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Great discription.";

            return View();
        }
    }
}