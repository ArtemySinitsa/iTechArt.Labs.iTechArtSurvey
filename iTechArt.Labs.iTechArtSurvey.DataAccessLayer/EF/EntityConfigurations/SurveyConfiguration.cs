using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            HasKey(s => new { s.Id, s.Version });
            HasRequired(s => s.Author);
            Property(s => s.Created).IsRequired();
            Property(s => s.Title).IsRequired().HasMaxLength(256);

            HasOptional(s => s.Editor);
            Property(s => s.Edited).IsOptional();

            HasMany(s => s.Lookups).WithRequired(l => l.Survey);
        }
    }
}
