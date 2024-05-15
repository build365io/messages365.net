using AutoMapper;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public PostsController(IPostRepository repo, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _repo = repo;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllPosts(string date)
        {
            return await _repo.GetPostsAsync(date);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(Guid id)
        {
            var post = await _repo.GetPostByIdAsync(id);
            
            if (post == null) return NotFound();

            return post;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            
            post.Author = User.Identity.Name;

            _repo.AddPost(post);

            var newPost = _mapper.Map<PostDto>(post);

            await _publishEndpoint.Publish(_mapper.Map<PostCreated>(newPost));

            var result = await _repo.SaveChangesAsync();;

            if (!result) return BadRequest("Could not save changes to the DB");

            return CreatedAtAction(nameof(GetPostById), 
                new {post.Id}, newPost);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            var post = await _repo.GetPostEntityById(id);

            if (post == null) return NotFound();

            _repo.RemovePost(post);

            await _publishEndpoint.Publish<PostDeleted>(new { Id = post.Id.ToString() });

            var result = await _repo.SaveChangesAsync();

            if (!result) return BadRequest("Could not update DB");

            return Ok();
        }
    }
}