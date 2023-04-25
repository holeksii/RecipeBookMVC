namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Services;

public sealed class LikeServiceTest
{
    readonly Mock<LikeRepository> likeRepositoryMock;
    readonly LikeService likeService;

    public LikeServiceTest()
    {
        likeRepositoryMock = new Mock<LikeRepository>();
        InitMockMethods();
        likeService = new LikeService(likeRepositoryMock.Object);
    }

    void InitMockMethods()
    {
    }

    [Fact]
    public void TestAddComment()
    {
        likeService.AddOrDeleteLike(1, 1);
    }
}
