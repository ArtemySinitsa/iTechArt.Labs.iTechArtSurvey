using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasKey(q => q.Id);
            HasOptional(q => q.Replies);
            HasRequired(q => q.SurveyQuestion)
               .WithOptional(s => s.Question)
               .WillCascadeOnDelete(true);

            Property(q => q.Required).IsRequired();
            Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(256);
            Property(q => q.Type).IsRequired();
        }
    }
}
