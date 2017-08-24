using System;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyPageQuestion
    {
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public Guid SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
        public int Order { get; set; }
    }
}
