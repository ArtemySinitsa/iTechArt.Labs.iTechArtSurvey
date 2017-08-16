using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public bool Required { get; set; }
        public string JsonMetaInformation { get; set; }
        public virtual SurveyPageQuestion SurveyPageQuestion { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}