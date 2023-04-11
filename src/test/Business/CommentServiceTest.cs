namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Data.Models;

public class CommentServiceTest
{
    static readonly Mock<CommentRepository> commentRepositoryMock;
    static readonly CommentRepository CommentRepository;

    static CommentServiceTest()
    {
        commentRepositoryMock = new Mock<CommentRepository>();
        InitMockMethods();
        CommentRepository = commentRepositoryMock.Object;
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
        var comment = CommentRepository.Add(1, 1, "Test");
        Assert.Equal("Test", comment?.Text);
        Assert.Equal(DateTime.Today, comment?.Time);
    }
}
