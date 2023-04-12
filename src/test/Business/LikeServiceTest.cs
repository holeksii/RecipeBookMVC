namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;

public class LikeServiceTest
{
    static readonly Mock<LikeRepository> likeRepositoryMock;
    static readonly LikeRepository likeRepository;
    static readonly LikeService likeService;

    static LikeServiceTest()
    {
        likeRepositoryMock = new Mock<LikeRepository>();
        InitMockMethods();
        likeRepository = likeRepositoryMock.Object;
        likeService = new LikeService(likeRepository);
    }

    static void InitMockMethods()
    {
    }

    [Fact]
    public void TestAddComment()
    {
        likeService.AddOrDeleteLike(1, 1);
    }
}
