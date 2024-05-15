using MongoDB.Entities;

namespace SearchService;

public class Item : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }
}
