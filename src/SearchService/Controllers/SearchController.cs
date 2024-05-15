using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        public SearchController()
        {
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> SearchItems([FromQuery]SearchParams searchParams)
        {
            var query = DB.PagedSearch<Item, Item>();

            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
            }

            query = searchParams.OrderBy switch 
            {
                "title" => query.Sort(x => x.Ascending(p => p.Title)),
                "content" => query.Sort(x => x.Ascending(p => p.Content)),
                _ => query.Sort(x => x.Descending(a => a.CreatedAt)) 
            };
            
            query.PageNumber(searchParams.PageNumber);
            query.PageSize(searchParams.PageSize);

            var result = await query.ExecuteAsync();

            return Ok(new
            {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });         

        }
    }
}