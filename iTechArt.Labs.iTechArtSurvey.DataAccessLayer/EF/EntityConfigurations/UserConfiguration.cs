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
            Property(u => u.Email).IsRequired();

            HasMany(u => u.SurveyLookups)
                .WithRequired(s => s.Author);

            HasMany(u => u.ReplyLookups)
                .WithOptional(r => r.User);
        }
    }
}
