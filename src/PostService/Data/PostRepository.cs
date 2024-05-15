using PostService.Data;
using PostService.DTOs;
using PostService.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace PostService;

public class PostRepository : IPostRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void AddPost(Post post)
    {
        _context.Posts.Add(post);
    }

    public async Task<PostDto> GetPostByIdAsync(Guid id)
    {
        return await _context.Posts
            .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Post> GetPostEntityById(Guid id)
    {
        return await _context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PostDto>> GetPostsAsync(string date)
    {
        var query = _context.Posts.OrderBy(x => x.CreatedAt).AsQueryable();

        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public void RemovePost(Post post)
    {
        _context.Posts.Remove(post);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}