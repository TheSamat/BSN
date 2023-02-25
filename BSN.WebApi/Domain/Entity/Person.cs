namespace BSN.WebApi.Domain.Entity
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? Place { get; set; }
        public Sex Sex { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string? Hash { get; set; }
        public List<Message> Messages { get; set; }
        public List<Tweet> Liked { get; set; }
        public List<Person> Following { get; set; }
    }
    public enum Sex
    {
        Hidden = 0,
        Male = 1,
        Female = 2,
        Other = 3,
    }
}
