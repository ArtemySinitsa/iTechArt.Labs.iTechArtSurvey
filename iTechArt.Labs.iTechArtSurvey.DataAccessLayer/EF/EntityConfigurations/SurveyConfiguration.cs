using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {

            HasKey(s => new { s.Id, s.Version });
            HasOptional(s => s.Author);
            HasOptional(s => s.Editor);
            HasMany(s => s.SurveyQuestions)
                .WithRequired(sq => sq.Survey)
                .WillCascadeOnDelete(true);

            Property(s => s.Created).IsRequired();
            Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(256);
            Property(s => s.Edited).IsOptional();
        }
    }
}
