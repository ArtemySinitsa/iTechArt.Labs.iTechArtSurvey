using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyPageConfiguration : EntityTypeConfiguration<SurveyPage>
    {
        public SurveyPageConfiguration()
        {
            Property(sp => sp.Number).IsRequired();
            Property(sp => sp.Title).IsRequired().HasMaxLength(256);

        }
    }
}
