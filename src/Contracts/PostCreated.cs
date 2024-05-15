namespace Contracts
{
    public class PostCreated
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}