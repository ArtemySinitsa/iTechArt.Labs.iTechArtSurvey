using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class TemplateConfiguration : EntityTypeConfiguration<Template>
    {
        public TemplateConfiguration()
        {
            Property(t => t.Description).IsRequired().HasMaxLength(256);

            HasRequired(t => t.Author);
            HasMany(t => t.Lookups).WithRequired(l => l.Template);
        }
    }
}
