using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private SurveyUserManager _userManager;
        private SurveyRoleManager _roleManager;

        private const int pageSize = 3;
        public UsersController()
        {

        }

        public UsersController(SurveyUserManager userManager, SurveyRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public SurveyUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SurveyUserManager>();
            }
        }

        public SurveyRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<SurveyRoleManager>();
            }
        }

        public ActionResult Index(string queryString, int? page = 1)
        {
            var query = GetUsersListView(queryString).ToList();

            ViewBag.CurrentPage = page.Value;
            ViewBag.Count = query.Count;
            ViewBag.QueryString = queryString;

            var users = GetListPageFromCollection<UserListViewModel>(query, page.Value, pageSize);

            return View(users.ToList());
        }

        private IEnumerable<T> GetListPageFromCollection<T>(IList<T> collection, int page, int pageSize)
        {
            int currentIndex = GetCurrentFirstItemIndex(page, pageSize);
            return collection.Skip(currentIndex).Take(pageSize);
        }

        private int GetCurrentFirstItemIndex(int page, int pageSize)
        {
            return ((page - 1) * pageSize);
        }

        private IEnumerable<UserListViewModel> GetUsersListView(string query)
        {
            IQueryable<User> users = null;
            if (string.IsNullOrWhiteSpace(query))
            {
                users = UserManager.Users;
            }
            else
            {
                users = UserManager.Users.Where(u =>
                string.Compare(u.Name, query, StringComparison.OrdinalIgnoreCase) == 0
                || string.Compare(u.Email, query, StringComparison.OrdinalIgnoreCase) == 0);
            }

            return users.ToList().Select(u =>
                        new UserListViewModel
                        {
                            Id = u.Id,
                            Name = u.Name ?? "none",
                            Email = u.Email,
                            Registered = u.RegisterDate,
                            Roles = string.Join(",", GetUserRoles(u.Id)),
                            SurveyCount = u.Surveys.Count
                        });
        }

        public async Task<ActionResult> Details(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            return View(user);
        }

        public ActionResult SendInvite()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendInvite([Bind(Include = "Email,Name")]InviteUserViewModel invitee)
        {
            if (!ModelState.IsValid)
            {
                return View(invitee);
            }
            var user = new User
            {
                Name = invitee.Name,
                Email = invitee.Email,
                UserName = invitee.Email,
            };

            var result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "user");

                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                var callbackUrl = Url.Action("CompleteRegistration", "Users", new { userId = user.Id, code = code },
                   protocol: Request.Url.Scheme);

                await UserManager.SendEmailAsync(user.Id, "<h2>Email confirmation</h2>",
                  "To confirm registration, please folow the link: <a href=\""
                                                  + callbackUrl + "\">complete registration</a>");
                return View("InvitationSend");
            }
            else
            {
                AddErrors(result);
                return View(invitee);
            }
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Roles")] UserEditViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await UserManager.ChangeNameAsync(user.Id, user.Name);

            await ChangeUserRole(user.Id, user.Roles.ToList());

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var userDeleteModel = new UserListViewModel
            {
                Id = user.Id,
                Name = user.Name ?? "none",
                Registered = user.RegisterDate.GetValueOrDefault(),
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
            return UserManager.GetRoles(userId).ToList();
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}
