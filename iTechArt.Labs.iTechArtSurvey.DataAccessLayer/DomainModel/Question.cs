using System.Xml.Linq;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public enum QuestionTypes
    {
        Textarea,
        Checkbox,
        Radio,
        File,
        Rate,
        Range
    }

    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionTypes Type { get; set; }
        public int Order { get; set; }
        public bool Required { get; set; }
        public string XmlContent { get; set; }
        public virtual SurveyPage SurveyPage{ get; set; }

        public XElement XmlContentWrapper
        {
            get { return XElement.Parse(XmlContent); }
            set { XmlContent = value.ToString(); }
        }
    }
}