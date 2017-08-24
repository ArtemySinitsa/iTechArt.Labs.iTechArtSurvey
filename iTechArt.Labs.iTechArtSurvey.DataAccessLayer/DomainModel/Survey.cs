using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Survey
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        [MinLength(1, ErrorMessage = "Survey title must be not empty")]
        public string Title { get; set; }
        public virtual User Author { get; set; }
        public DateTime Created { get; set; }
        public virtual User Editor { get; set; }
        public DateTime? Edited { get; set; }
        public virtual ICollection<SurveyLookup> Lookups { get; set; }
    }
}
