using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasRequired(q => q.SurveyPageQuestion)
                .WithRequiredPrincipal(q => q.Question);
            HasOptional(q => q.Replies);

            Property(q => q.Required).IsRequired();
            Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(256);
            Property(q => q.Type).IsRequired();
        }
    }
}
