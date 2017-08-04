using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Reply
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Question Question { get; set; }
        public UserReply UserReply { get; set; }
    }
}
