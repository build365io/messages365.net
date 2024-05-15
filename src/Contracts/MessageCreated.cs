namespace Contracts
{
    public class MessageCreated
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}