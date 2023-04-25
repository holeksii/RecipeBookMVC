namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Repositories;
using RecipeBook.Data.Services;
using RecipeBook.Data.Models;

public sealed class UserServiceTest
{
    readonly Mock<UserRepository> userRepositoryMock;
    readonly UserService userService;

    public UserServiceTest()
    {
        userRepositoryMock = new Mock<UserRepository>();
        InitMockMethods();
        userService = new(userRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        userRepositoryMock.Setup(r =>
                r.Get(It.IsAny<long>())).Returns
                (
                    User.CreateBuilder()
                    .SetUsername("Username")
                    .SetPassword("Password")
                    .SetEmail("Email")
                    .Build()
                );
    }

    [Fact]
    public void TestGetUser()
    {
        var user = userService.GetUser(1);
        Assert.NotNull(user);
        Assert.Equal("Username", user?.Username);
        Assert.Equal("Password", user?.Password);
        Assert.Equal("Email", user?.Email);
    }
}
