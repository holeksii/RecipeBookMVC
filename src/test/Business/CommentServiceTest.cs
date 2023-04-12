namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;

public class CommentServiceTest
{
    static readonly Mock<CommentRepository> commentRepositoryMock;
    static readonly CommentRepository CommentRepository;
    static readonly CommentService commentService;

    static CommentServiceTest()
    {
        commentRepositoryMock = new Mock<CommentRepository>();
        InitMockMethods();
        CommentRepository = commentRepositoryMock.Object;
        commentService = new CommentService(CommentRepository);
    }

    static void InitMockMethods()
    {
        commentRepositoryMock.Setup(r =>
                r.Add(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>())).
            Returns(
                new Comment("Test", DateTime.Today));
    }

    [Fact]
    public void TestAddComment()
    {
        var comment = commentService.AddComment(1, 1, "Test");
        Assert.Equal("Test", comment?.Text);
        Assert.Equal(DateTime.Today, comment?.Time);
    }
}
