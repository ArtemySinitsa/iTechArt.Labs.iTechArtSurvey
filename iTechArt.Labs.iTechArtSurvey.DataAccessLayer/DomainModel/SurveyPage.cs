using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyPage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public virtual ICollection<SurveyPageQuestion> SurveyPageQuestions { get; set; }
    }
}
