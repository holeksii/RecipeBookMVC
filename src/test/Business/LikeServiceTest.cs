namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;

// public class LikeServiceTest
// {
//     static readonly Mock<LikeRepository> likeRepositoryMock;
//     static readonly LikeRepository likeRepository;
//     static readonly LikeService likeService;

//     static LikeServiceTest()
//     {
//         likeRepositoryMock = new Mock<LikeRepository>();
//         InitMockMethods();
//         likeRepository = likeRepositoryMock.Object;
//         likeService = new LikeService(likeRepository);
//     }

//     static void InitMockMethods()
//     {
//         likeRepositoryMock.Setup(r =>
//                 r.AddOrDelete(It.IsAny<long>(), It.IsAny<long>())).
//     }

//     [Fact]
//     public void TestAddComment()
//     {
//         var comment = likeService.AddComment(1, 1, "Test");
//         Assert.Equal("Test", comment?.Text);
//         Assert.Equal(DateTime.Today, comment?.Time);
//     }
// }
