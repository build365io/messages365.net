using PostService.RequestHelpers;
using AutoFixture;
using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PostService.Controllers;
using PostService.DTOs;

namespace PostService.UnitTests;

public class PostControllerTests
{
    private readonly Mock<IPostRepository> _postRepo;
    private readonly Mock<IPublishEndpoint> _publishEndpoint;
    private readonly Fixture _fixture;
    private readonly PostsController _controller;
    private readonly IMapper _mapper;

    public PostControllerTests()
    {
        _fixture = new Fixture();
        _postRepo = new Mock<IPostRepository>();
        _publishEndpoint = new Mock<IPublishEndpoint>();

        var mockMapper = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(MappingProfiles).Assembly);
        }).CreateMapper().ConfigurationProvider;

        _mapper = new Mapper(mockMapper);
        _controller = new PostsController(_postRepo.Object, _mapper, _publishEndpoint.Object);
    }

    [Fact]
    public async Task GetPosts_WithNoParams_Returns10Posts()
    {
        // arrange
        var posts = _fixture.CreateMany<PostDto>(10).ToList();
        _postRepo.Setup(repo => repo.GetPostsAsync(null)).ReturnsAsync(posts);

        // act
        var result = await _controller.GetAllPosts(null);

        // assert
        Assert.Equal(10, result.Value.Count);
        Assert.IsType<ActionResult<List<PostDto>>>(result);
    }

}