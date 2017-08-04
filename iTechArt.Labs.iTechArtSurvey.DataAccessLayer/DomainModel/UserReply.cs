using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class UserReply
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Survey Survey { get; set; }
        public Template Template { get; set; }
        public Reply Reply { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}

