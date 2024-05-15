using PostService.Entities;

namespace PostService.UnitTests;

public class PostEntityTests
{
    [Fact]
    public void ContentLength_ContentLengthGt20_True()
    {
        var post = new Post{Id = Guid.NewGuid(), Content = "aaaaabbbbbaaaaabbbbbaaaaa"};
        
        var result = post.ContentLength();

        Assert.True(result);        
    }
    
    [Fact]
    public void ContentLength_ContentLengthGt20_False()
    {
        var post = new Post{Id = Guid.NewGuid(), Content = "aaaaabbbbbaaaaabbb"};
        
        var result = post.ContentLength();

        Assert.False(result);        
    }
}