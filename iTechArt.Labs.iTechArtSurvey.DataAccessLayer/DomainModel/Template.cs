using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Template
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public TemplateLookup Lookup { get; set; }
    }
}
