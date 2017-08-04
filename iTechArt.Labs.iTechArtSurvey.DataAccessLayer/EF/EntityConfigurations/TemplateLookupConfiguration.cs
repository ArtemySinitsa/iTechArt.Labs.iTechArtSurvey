using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class TemplateLookupConfiguration : EntityTypeConfiguration<TemplateLookup>
    {
        public TemplateLookupConfiguration()
        {
            HasRequired(t => t.Template);
            HasRequired(sl => sl.SurveyPages).WithRequiredDependent();
        }
    }
}
