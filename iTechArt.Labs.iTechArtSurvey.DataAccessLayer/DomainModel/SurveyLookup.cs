using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyLookup
    {
        public int Id { get; set; }
        public Survey Survey { get; set; }
        public virtual ICollection<SurveyPage> SurveyPages { get; set; }
    }
}