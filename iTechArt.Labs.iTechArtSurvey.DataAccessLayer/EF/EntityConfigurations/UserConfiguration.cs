using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Email).IsRequired().HasMaxLength(256);
            Property(u => u.Name).IsRequired().HasMaxLength(256);
            Property(u => u.Password).IsRequired().HasMaxLength(256);

            HasMany(u => u.Surveys)
                .WithRequired(u => u.Author);

            HasMany(u => u.Templates)
                .WithRequired(t => t.Author);

        }
    }
}
