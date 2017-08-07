using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class TemplateConfiguration : EntityTypeConfiguration<Template>
    {
        public TemplateConfiguration()
        {
            Property(t => t.Description).IsRequired().HasMaxLength(256);

            HasRequired(t => t.Author);
            HasRequired(t => t.Lookup).WithRequiredPrincipal(l=>l.Template);
        }
    }
}
