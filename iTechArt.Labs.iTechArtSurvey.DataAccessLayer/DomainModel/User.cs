using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class User : IdentityUser
    {
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<UserReply> Replies { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Template> Templates { get; set; }
    }
}
