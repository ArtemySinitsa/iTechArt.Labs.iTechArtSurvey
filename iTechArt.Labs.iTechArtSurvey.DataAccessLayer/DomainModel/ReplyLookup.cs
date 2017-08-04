using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class ReplyLookup
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string ExternalUserId { get; set; }
    }
}
