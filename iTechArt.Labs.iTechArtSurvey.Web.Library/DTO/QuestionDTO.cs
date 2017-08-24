using System;
using System.Collections.Generic;
namespace iTechArt.Labs.iTechArtSurvey.Web.Library.DTO
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}