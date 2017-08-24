using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MinLength(1, ErrorMessage = "Question title must be not empty")]
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public bool Required { get; set; }
        public string JsonMetaInformation { get; set; }
        public virtual SurveyPageQuestion SurveyPageQuestion { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}