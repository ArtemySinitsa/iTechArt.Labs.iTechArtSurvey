using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using iTechArt.Labs.iTechArtSurvey.Web.Models;
using Microsoft.AspNet.Identity.Owin;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{
    public class UsersController : Controller
    {
        private SurveyUserManager _userManager;
        private IRepository<User> _repository;
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }
        public SurveyUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SurveyUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Users
        public async Task<ActionResult> Index()
        {
            var query = await _repository.GetAllAsync();
            var users = query.Select(u =>
            new UserListViewModel
            {
                Name = u.UserName,
                Registered = u.RegisterDate,
                Roles = string.Join(",", UserManager.GetRolesAsync(u.Id).Result),
                SurveyCount = u.Surveys.Count
            });
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
