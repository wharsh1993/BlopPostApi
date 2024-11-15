using Xunit;

public class PostServiceTests
{
    private readonly BlogRepository _postService;

    public PostServiceTests()
    {
       _postService = new BlogRepository();
    }

    [Fact]
    public async Task GetAllPosts_ShouldReturnAllPosts()
    {
        // Act
        var result = await _postService.GetAll();

        // Assert
        Assert.Equal(2, result.Count);
    }

     [Fact]
    public  void GetPosts_ShouldReturnPosts()
    {
        // Act
        var result =  _postService.GetById(6);
        // Assert
        Assert.NotNull(result);
       
    }
}
