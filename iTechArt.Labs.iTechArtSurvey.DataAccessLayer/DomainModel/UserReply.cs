using System;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class UserReply
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Reply Reply { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}

