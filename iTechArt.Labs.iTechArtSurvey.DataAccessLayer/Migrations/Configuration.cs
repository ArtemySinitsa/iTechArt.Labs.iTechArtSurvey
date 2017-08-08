namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using DomainModel;
    using EF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SurveyContext context)
        {

        }
    }
}
