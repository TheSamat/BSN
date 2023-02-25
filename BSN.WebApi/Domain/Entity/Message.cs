namespace BSN.WebApi.Domain.Entity
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Text { get; set; }
        public Person Author { get; set; }
        public Tweet Twit { get; set; }
    }
}
