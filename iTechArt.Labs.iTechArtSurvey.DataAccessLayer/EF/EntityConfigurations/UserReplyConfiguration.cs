using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class UserReplyConfiguration : EntityTypeConfiguration<UserReply>
    {
        public UserReplyConfiguration()
        {
            HasOptional(ur => ur.User);
            HasRequired(ur => ur.Survey);

            Property(ur => ur.ReplyDateTime).IsRequired();
        }
    }
}
