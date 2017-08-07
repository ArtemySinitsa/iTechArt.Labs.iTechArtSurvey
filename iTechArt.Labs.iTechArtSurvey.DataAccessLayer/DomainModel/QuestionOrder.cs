using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class QuestionOrder
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public virtual Question Question { get; set; }
        public SurveyPage SurveyPage { get; set; }
    }
}
