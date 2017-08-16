using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class UserReplyConfiguration : EntityTypeConfiguration<UserReply>
    {
        public UserReplyConfiguration()
        {
            HasOptional(ur => ur.User);
            HasRequired(ur => ur.Survey);

            Property(ur => ur.ReplyDateTime).IsRequired();
        }
    }
}
