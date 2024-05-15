namespace SearchService;

public class SearchParams
{
    public string SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 8;
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public string OrderBy { get; set; }
    public string FilterBy { get; set; }
}
