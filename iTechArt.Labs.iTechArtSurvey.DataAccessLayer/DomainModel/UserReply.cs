using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class UserReply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Reply Reply { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}

