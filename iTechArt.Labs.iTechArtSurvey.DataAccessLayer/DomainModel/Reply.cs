namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel
{
    public class Reply
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Question Question { get; set; }
        public virtual UserReply UserReply { get; set; }
    }
}
