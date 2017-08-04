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
            Ignore(q => q.XmlContentWrapper);
            HasRequired(q => q.SurveyPage);
            HasOptional(q => q.Replies);
            HasMany(q => q.Replies).WithRequired(q => q.Question);

            Property(q => q.XmlContent).HasColumnType("xml");
            Property(q => q.Required).IsRequired();
            Property(q => q.Title).IsRequired();
            Property(q => q.Type).IsRequired();
            
        }
    }
}
