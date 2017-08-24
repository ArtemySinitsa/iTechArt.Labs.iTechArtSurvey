using System;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyLookup
    {
        public Guid SurveyPageId { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
    }
}