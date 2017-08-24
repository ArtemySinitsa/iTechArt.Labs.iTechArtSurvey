using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Value { get; set; }
        public virtual Question Question { get; set; }
        public virtual UserReply UserReply { get; set; }
    }
}
