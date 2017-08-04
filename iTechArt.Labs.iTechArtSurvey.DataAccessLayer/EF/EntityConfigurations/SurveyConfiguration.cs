using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            Property(s => s.Title).IsRequired().HasMaxLength(256);
            Property(s => s.LastModified).IsRequired();
            HasRequired(s => s.Lookup).WithRequiredPrincipal(l=>l.Survey);
            HasRequired(s => s.Author);
        }
    }
}
