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
        public virtual ICollection<UserReply> Replies { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Template> Templates { get; set; }

    }
}
