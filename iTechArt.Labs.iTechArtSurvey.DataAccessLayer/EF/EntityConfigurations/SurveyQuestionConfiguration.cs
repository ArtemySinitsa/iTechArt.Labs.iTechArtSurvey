using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class SurveyQuestionConfiguration : EntityTypeConfiguration<SurveyQuestion>
    {
        public SurveyQuestionConfiguration()
        {
            HasKey(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(s => s.Survey)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(q => new { q.SurveyId, q.SurveyVersion }).WillCascadeOnDelete(true);
        }
    }
}
