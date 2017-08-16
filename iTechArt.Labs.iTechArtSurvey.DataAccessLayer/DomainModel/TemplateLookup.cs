namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class TemplateLookup
    {
        public int SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
        public virtual Template Template { get; set; }
    }
}
