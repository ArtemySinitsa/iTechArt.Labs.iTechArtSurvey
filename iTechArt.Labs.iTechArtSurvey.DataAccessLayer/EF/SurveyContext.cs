using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF
{
    public class SurveyContext : IdentityDbContext<User>
    {
        public SurveyContext() : base("SurveyContext")
        {

        }

        public SurveyContext(string connectionStringName) : base(connectionStringName)
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Template> Templates { get; set; }
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

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SurveyConfiguration());
            modelBuilder.Configurations.Add(new TemplateConfiguration());
            modelBuilder.Configurations.Add(new TemplateLookupConfiguration());
            modelBuilder.Configurations.Add(new UserReplyConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new ReplyConfiguration());
            modelBuilder.Configurations.Add(new SurveyPageConfiguration());
            modelBuilder.Configurations.Add(new SurveyLookupConfiguration());
            modelBuilder.Configurations.Add(new SurveyPageQuestionConfiguration());
        }

        public static SurveyContext Create()
        {
            return new SurveyContext();
        }
    }
}
