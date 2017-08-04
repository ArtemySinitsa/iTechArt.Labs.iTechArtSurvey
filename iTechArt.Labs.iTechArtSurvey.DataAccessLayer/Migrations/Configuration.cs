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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.Add(new Role { Name = "Admin" });
            context.Roles.Add(new Role { Name = "User" });
        }
    }
}
