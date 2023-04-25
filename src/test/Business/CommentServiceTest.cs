namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Models;
using RecipeBook.Business.Services;

public sealed class CommentServiceTest
{
    readonly Mock<CommentRepository> _commentRepositoryMock;
    readonly CommentService _commentService;
    readonly DateTime _startOfTime;

    public CommentServiceTest()
    {
        _commentRepositoryMock = new Mock<CommentRepository>();
        _startOfTime = new DateTime(2021, 1, 1);
        InitMockMethods();
        _commentService = new CommentService(_commentRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        _commentRepositoryMock.Setup(r =>
                r.Add(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>())).
            Returns(
                new Comment("Test", _startOfTime));
    }

    [Fact]
    public void TestAddComment()
    {
        var comment = _commentService.AddComment(1, 1, "Test");
        Assert.Equal("Test", comment?.Text);
        Assert.Equal(_startOfTime, comment?.Time);
    }
}
