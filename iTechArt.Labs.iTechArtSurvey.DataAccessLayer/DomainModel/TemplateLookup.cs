﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class TemplateLookup
    {
        public int Id { get; set; }
        public Template Template { get; set; }
        public virtual ICollection<SurveyPage> SurveyPages { get; set; }
    }
}