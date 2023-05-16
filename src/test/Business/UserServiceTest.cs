using RecipeBookTest.Business.Proxy;

namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Models;
using RecipeBook.Business.Services;

public sealed class UserServiceTest
{
    readonly Mock<UserRepositoryMoqProxy> _userRepositoryMock;
    readonly UserService _userService;

    public UserServiceTest()
    {
        _userRepositoryMock = new Mock<UserRepositoryMoqProxy>();
        InitMockMethods();
        _userService = new(_userRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        _userRepositoryMock.Setup(r =>
            r.Get(It.IsAny<long>())).Returns
        (
            new User
            {
                UserName = "Username",
                Email = "Email"
            }
        );
    }

    [Fact]
    public void TestGetUser()
    {
        var user = _userService.GetUser("1");
        Assert.NotNull(user);
        Assert.Equal("Username", user?.UserName);
        Assert.Equal("Password", user?.UserName);
        Assert.Equal("Email", user?.Email);
    }
}