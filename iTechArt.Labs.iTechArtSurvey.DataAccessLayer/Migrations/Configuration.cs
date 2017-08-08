namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    using EF;

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
