using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Abstract;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF
{
    public class SurveyContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SurveyLookupConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
