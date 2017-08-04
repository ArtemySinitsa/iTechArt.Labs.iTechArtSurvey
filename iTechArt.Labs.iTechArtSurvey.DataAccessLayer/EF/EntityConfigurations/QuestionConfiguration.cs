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
            Property(q => q.XmlContent).HasColumnType("xml");
            Ignore(q => q.XmlContentWrapper);
        }
    }
}
