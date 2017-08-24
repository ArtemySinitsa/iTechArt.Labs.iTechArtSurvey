using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyLookupConfiguration : EntityTypeConfiguration<SurveyLookup>
    {
        public SurveyLookupConfiguration()
        {
            HasKey(sl => sl.SurveyPageId);
            HasRequired(sl => sl.SurveyPage).WithRequiredDependent().WillCascadeOnDelete(true);
        }
    }
}
