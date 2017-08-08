using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyLookup
    {
        public Survey Survey { get; set; }
        public int SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
    }
}