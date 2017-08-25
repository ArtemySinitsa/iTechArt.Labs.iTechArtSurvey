using System;
using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.Web.Library.DTO
{
    public class SurveyDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public IEnumerable<QuestionDTO> Questions { get; set; }
    }
}