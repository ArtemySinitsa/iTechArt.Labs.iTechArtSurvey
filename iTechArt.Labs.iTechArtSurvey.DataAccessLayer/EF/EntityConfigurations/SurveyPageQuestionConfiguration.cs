using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyPageQuestionConfiguration : EntityTypeConfiguration<SurveyPageQuestion>
    {
        public SurveyPageQuestionConfiguration()
        {
            HasKey(s => new { s.QuestionId });
            HasRequired(s => s.Question).WithRequiredDependent();
            HasRequired(s => s.SurveyPage)
                .WithMany(s => s.SurveyPageQuestions)
                .HasForeignKey(q => q.SurveyPageId);

            Property(s => s.Order).IsRequired();
        }
    }
}
