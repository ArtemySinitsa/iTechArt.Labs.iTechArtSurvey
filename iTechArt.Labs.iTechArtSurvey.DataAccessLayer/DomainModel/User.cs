using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<SurveyLookup> SurveyLookups { get; set; }
        public virtual ICollection<ReplyLookup> ReplyLookups { get; set; }

    }
}
