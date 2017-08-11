using System.Collections.Generic;
using System.Data.Entity;
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
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private SurveyUserManager _userManager;
        private SurveyRoleManager _roleManager;

        private readonly IRepository<User> _repository;
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

        public SurveyRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<SurveyRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var query = await UserManager.Users.ToListAsync();
            var users = query.Select(u =>
            new UserListViewModel
            {
                Id = u.Id,
                Name = u.Name ?? "none",
                Registered = u.RegisterDate,
                Roles = string.Join(",", GetUserRoles(u.Id)),
                SurveyCount = u.Surveys.Count
            });
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            return View(user);
        }

        //// GET: Users/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var userEditModel = new UserEditViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Roles = GetUserRoles(id)
            };

            ViewBag.Roles = RoleManager.Roles.Select(r => r.Name);

            return View(userEditModel);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Roles")] UserEditViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                var storedUser = await UserManager.FindByIdAsync(user.Id);
                storedUser.Name = user.Name;

                await ChangeUserRole(storedUser.Id, user.Roles.ToList());

                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var userDeleteModel = new UserListViewModel
            {
                Id = user.Id,
                Name = user.Name ?? "none",
                Registered = user.RegisterDate,
                Roles = string.Join(",", GetUserRoles(user.Id)),
                SurveyCount = user.Surveys.Count
            };
            return View(userDeleteModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);
                var result = await UserManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region Helpers
        private List<string> GetUserRoles(string userId)
        {
            return UserManager.GetRolesAsync(userId).Result.ToList();
        }

        private async Task ChangeUserRole(string userId, List<string> newRoles)
        {
            var currentRoles = GetUserRoles(userId);
            foreach (var role in currentRoles)
            {
                await UserManager.RemoveFromRoleAsync(userId, role);
            }

            foreach (var role in newRoles)
            {
                await UserManager.AddToRoleAsync(userId, role);
            }
        }

        #endregion
    }
}
