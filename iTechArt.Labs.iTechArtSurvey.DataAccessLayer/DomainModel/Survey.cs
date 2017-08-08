using System;
using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Survey
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public virtual User Author { get; set; }
        public DateTime Created { get; set; }
        public virtual User Editor { get; set; }
        public DateTime Edited { get; set; }
        public virtual ICollection<SurveyLookup> Lookups { get; set; }

    }
}
