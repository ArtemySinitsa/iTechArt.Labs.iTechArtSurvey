using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SurveyLookup Lookup { get; set; }
        public User Author { get; set; }
        public DateTime LastModified { get; set; }
    }
}
