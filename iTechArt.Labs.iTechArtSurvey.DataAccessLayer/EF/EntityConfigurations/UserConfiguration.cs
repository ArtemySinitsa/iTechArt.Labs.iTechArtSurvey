using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Email).IsRequired().HasMaxLength(256);
            Property(u => u.Name).IsRequired().HasMaxLength(256);
            Property(u => u.Password).IsRequired().HasMaxLength(256);

            HasMany(u => u.Surveys);

            HasMany(u => u.Templates)
                .WithRequired(t => t.Author);

        }
    }
}
