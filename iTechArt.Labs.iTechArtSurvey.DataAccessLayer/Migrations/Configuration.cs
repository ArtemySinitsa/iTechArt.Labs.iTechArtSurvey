namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using DomainModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.SurveyContext context)
        {

            context.Roles.Add(new Role { Name = "Admin" });
            context.Roles.Add(new Role { Name = "User" });
        }
    }
}
