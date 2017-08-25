using System;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class SurveyQuestion
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public Guid SurveyId { get; set; }
        public int SurveyVersion { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Question Question { get; set; }
    }
}
