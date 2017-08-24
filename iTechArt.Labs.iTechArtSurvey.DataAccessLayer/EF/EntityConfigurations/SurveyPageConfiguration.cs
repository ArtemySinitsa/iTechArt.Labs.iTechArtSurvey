using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyPageConfiguration : EntityTypeConfiguration<SurveyPage>
    {
        public SurveyPageConfiguration()
        {
            HasKey(s => s.Id);
            Property(sp => sp.Number).IsOptional();
            Property(sp => sp.Title)
                .IsOptional()
                .HasMaxLength(256);
            HasMany(sp => sp.SurveyPageQuestions)
                .WithRequired(s => s.SurveyPage)
                .WillCascadeOnDelete(true);
        }
    }
}
