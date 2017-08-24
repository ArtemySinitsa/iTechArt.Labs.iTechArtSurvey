using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class TemplateLookup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SurveyPageId { get; set; }
        public virtual SurveyPage SurveyPage { get; set; }
        public virtual Template Template { get; set; }
    }
}
