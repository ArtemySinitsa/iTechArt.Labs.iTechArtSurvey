using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Account;
using iTechArt.Labs.iTechArtSurvey.Web.ViewModels.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace iTechArt.Labs.iTechArtSurvey.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private SurveyUserManager _userManager;

        public RegistrationController()
        {

        }

        public RegistrationController(SurveyUserManager userManager)
        {
            _userManager = userManager;
        }

        public SurveyUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SurveyUserManager>();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("Index")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User { UserName = model.Email, Name = model.Name, Email = model.Email, RegisterDate = DateTime.Now };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "user");

                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                var callbackUrl = Url.Action("ConfirmEmail", "Registration", new { userId = user.Id, code = code },
                   protocol: Request.Url.Scheme);

                await UserManager.SendEmailAsync(user.Id, "<h2>Email confirmation</h2>",
                  "To confirm registration, please folow the link: <a href=\""
                                                  + callbackUrl + "\">complete registration</a>");
                return View("UnconfirmedEmail");
            }
            else
            {
                AddErrors(result);
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Complete(string userId, string code)
        {
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                var storedUser = await UserManager.FindByIdAsync(userId);
                var user = new InvitedUserRegisterViewModel
                {
                    Id = storedUser.Id,
                    Email = storedUser.Email,
                    Name = storedUser.Name
                };
                return View(user);
            }
            else
            {
                return View("InvitationError");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Complete([Bind(Include = "Id,Name,Email,Password,ConfirmPassword")]InvitedUserRegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var result = await UserManager.RegisterInvitedUser(user.Id, user.Email, user.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                AddErrors(result);
                return View(user);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}