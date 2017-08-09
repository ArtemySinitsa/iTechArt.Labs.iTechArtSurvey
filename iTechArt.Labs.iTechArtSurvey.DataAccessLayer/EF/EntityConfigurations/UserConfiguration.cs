using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(u => u.Surveys)
                .WithRequired(u => u.Author);

            HasMany(u => u.Templates)
                .WithRequired(t => t.Author);
        }
    }
}
