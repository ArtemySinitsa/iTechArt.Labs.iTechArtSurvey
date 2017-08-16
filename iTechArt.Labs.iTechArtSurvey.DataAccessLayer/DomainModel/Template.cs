using System;
using System.Collections.Generic;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Template
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<TemplateLookup> Lookups { get; set; }
    }
}
