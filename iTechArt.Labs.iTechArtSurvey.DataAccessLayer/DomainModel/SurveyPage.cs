using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public virtual ICollection<SurveyPageQuestion> SurveyPageQuestions { get; set; }
    }
}
