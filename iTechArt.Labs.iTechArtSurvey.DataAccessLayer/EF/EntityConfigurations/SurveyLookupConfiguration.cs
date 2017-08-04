﻿using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF.EntityConfigurations
{
    class SurveyLookupConfiguration : EntityTypeConfiguration<SurveyLookup>
    {
        public SurveyLookupConfiguration()
        {
            HasOptional(sl => sl.Survey);
            HasOptional(sl => sl.Template);
        }
    }
}
