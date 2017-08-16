using System.Data.Entity.Migrations;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EF.SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.SurveyContext";
        }

        protected override void Seed(EF.SurveyContext context)
        {

        }
    }
}
