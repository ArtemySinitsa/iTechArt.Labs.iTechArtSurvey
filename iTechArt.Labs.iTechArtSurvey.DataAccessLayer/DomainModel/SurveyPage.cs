using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyPage
    {
        public int Id { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
