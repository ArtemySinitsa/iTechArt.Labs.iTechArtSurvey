using System;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.UserManagement
{
    public class SurveyUserManager : UserManager<User>
    {
        public SurveyUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static SurveyUserManager Create(IdentityFactoryOptions<SurveyUserManager> options, IOwinContext context)
        {
            var manager = new SurveyUserManager(SurveyUserStore.Create(context));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }
}
