using System;
using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.BusinessLayer;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.Labs.iTechArtSurvey.Web.Models
{
    public class SurveyContextInitializer : DropCreateDatabaseAlways<SurveyContext>
    {
        protected override void Seed(SurveyContext context)
        {
            var userManager = new SurveyUserManager(new UserStore<User>(context));
            var roleManager = new SurveyRoleManager(context);

            var admin = new IdentityRole { Name = "admin" };
            var user = new IdentityRole { Name = "user" };

            roleManager.CreateAsync(admin).Wait();

            roleManager.CreateAsync(user).Wait();

            var adminEntity = new User
            {
                UserName = "administrator",
                Email = "administratorskiemail@email.ad",
                RegisterDate = DateTime.Now
            };
            string password = "Admin123";

            var result = userManager.CreateAsync(adminEntity, password).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(adminEntity.Id, "admin").Wait();
            }

            base.Seed(context);
        }

    }
}