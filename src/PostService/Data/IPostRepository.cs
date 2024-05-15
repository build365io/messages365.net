using PostService.DTOs;
using PostService.Entities;

namespace PostService;

public interface IPostRepository
{
    Task<List<PostDto>> GetPostsAsync(string date);
    Task<PostDto> GetPostByIdAsync(Guid id);
    Task<Post> GetPostEntityById(Guid id);
    void AddPost(Post post);
    void RemovePost(Post post);
    Task<bool> SaveChangesAsync();
}