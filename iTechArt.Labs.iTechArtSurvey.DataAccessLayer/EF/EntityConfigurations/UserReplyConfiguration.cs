using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class UserReplyConfiguration : EntityTypeConfiguration<UserReply>
    {
        public UserReplyConfiguration()
        {
            HasKey(ur => ur.Id)
                .Property(ur => ur.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(ur => ur.User);
            HasRequired(ur => ur.Survey);
            Property(ur => ur.ReplyDateTime).IsRequired();
        }
    }
}
