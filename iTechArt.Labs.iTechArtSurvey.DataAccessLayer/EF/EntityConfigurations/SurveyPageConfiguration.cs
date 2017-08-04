using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class SurveyPageConfiguration : EntityTypeConfiguration<SurveyPage>
    {
        public SurveyPageConfiguration()
        {
            Property(sp => sp.Number).IsRequired();
            Property(sp => sp.Title).IsRequired().HasMaxLength(256);
        }
    }
}
