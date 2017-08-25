using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    internal class ReplyConfiguration : EntityTypeConfiguration<Reply>
    {
        public ReplyConfiguration()
        {
            HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(r => r.Question).WithMany(q => q.Replies);
            HasRequired(r => r.UserReply);
            Property(r => r.Value).IsRequired();
        }
    }
}
