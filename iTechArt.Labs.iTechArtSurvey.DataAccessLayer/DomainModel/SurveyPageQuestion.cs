namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyPageQuestion
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
        public int Order { get; set; }

    }
}
