namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Services;
using RecipeBook.Data.Models;

public sealed class CommentServiceTest
{
    readonly Mock<CommentRepository> commentRepositoryMock;
    readonly CommentService commentService;
    readonly DateTime startOfTime;

    public CommentServiceTest()
    {
        commentRepositoryMock = new Mock<CommentRepository>();
        startOfTime = new DateTime(2021, 1, 1);
        InitMockMethods();
        commentService = new CommentService(commentRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        commentRepositoryMock.Setup(r =>
                r.Add(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>())).
            Returns(
                new Comment("Test", startOfTime));
    }

    [Fact]
    public void TestAddComment()
    {
        var comment = commentService.AddComment(1, 1, "Test");
        Assert.Equal("Test", comment?.Text);
        Assert.Equal(startOfTime, comment?.Time);
    }
}
