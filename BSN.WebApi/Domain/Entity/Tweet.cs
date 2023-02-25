namespace BSN.WebApi.Domain.Entity
{
    public class Tweet : IEntity
    {
        public Guid TweetId { get; set; }
        public string Text { get; set; }
        public Person Author { get; set; }
        public Tweet Quote { get; set; }
        public List<Tweet> Comments { get; set; }
    }
}
