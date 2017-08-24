using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF
{
    public class SurveyContext : IdentityDbContext<User>
    {
        public SurveyContext() : base(DatabaseConfig.GetConnectionStringWithCredentials("SurveyContext"))
        {

        }

        public SurveyContext(string connectionStringName) : base(connectionStringName)
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins", "dbo");
            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUser>().Ignore(iu => iu.PhoneNumber);
            modelBuilder.Entity<IdentityUser>().Ignore(iu => iu.PhoneNumberConfirmed);

            modelBuilder.Configurations
                .Add(new UserConfiguration())
                .Add(new SurveyConfiguration())
                .Add(new UserReplyConfiguration())
                .Add(new QuestionConfiguration())
                .Add(new ReplyConfiguration())
                .Add(new SurveyPageConfiguration())
                .Add(new SurveyLookupConfiguration())
                .Add(new SurveyPageQuestionConfiguration());
        }

        public static SurveyContext Create()
        {
            return new SurveyContext();
        }
    }
}
