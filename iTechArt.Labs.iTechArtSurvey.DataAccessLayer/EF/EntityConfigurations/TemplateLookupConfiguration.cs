using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class TemplateLookupConfiguration : EntityTypeConfiguration<TemplateLookup>
    {
        public TemplateLookupConfiguration()
        {
            HasKey(tl => tl.SurveyPageId);
            HasRequired(tl => tl.SurveyPage).WithRequiredDependent();
        }
    }
}
