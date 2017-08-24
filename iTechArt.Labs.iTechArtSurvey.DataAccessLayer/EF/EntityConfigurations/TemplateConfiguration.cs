using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class TemplateConfiguration : EntityTypeConfiguration<Template>
    {
        public TemplateConfiguration()
        {
            HasKey(t => t.Id);
            HasRequired(t => t.Author);
            HasMany(t => t.Lookups).WithRequired(l => l.Template);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
