using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class TemplateLookup
    {
        public Template Template { get; set; }
        public int SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
    }
}
