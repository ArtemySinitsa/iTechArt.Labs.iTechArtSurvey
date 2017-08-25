using System;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Reply
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public virtual Question Question { get; set; }
        public virtual UserReply UserReply { get; set; }
    }
}
