using System;
namespace iTechArt.Labs.iTechArtSurvey.Web.Library.DTO
{
    public class SurveyDescriptionDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int QuestionsCount { get; set; }
    }
}