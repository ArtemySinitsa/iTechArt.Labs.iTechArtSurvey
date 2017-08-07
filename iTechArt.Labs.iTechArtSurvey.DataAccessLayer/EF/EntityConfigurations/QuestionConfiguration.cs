using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasRequired(q => q.QuestionOrder);
            HasOptional(q => q.Replies);
            HasMany(q => q.Replies).WithRequired(q => q.Question);

            Property(q => q.Required).IsRequired();
            Property(q => q.Title).IsRequired().HasMaxLength(256);
            Property(q => q.Type).IsRequired();
            
        }
    }
}
