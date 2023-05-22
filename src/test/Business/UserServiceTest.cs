using RecipeBookTest.Business.Proxy;

namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Data.Models;
using RecipeBook.Business.Services;

public sealed class UserServiceTest
{
    readonly Mock<UserRepositoryMoqProxy> _userRepositoryMock;
    readonly UserService _userService;

    readonly User _testUser = new()
    {
        UserName = "Username",
        Email = "Email",
        ImageUrl = "ImageUrl",
    };

    public UserServiceTest()
    {
        _userRepositoryMock = new Mock<UserRepositoryMoqProxy>();
        InitMockMethods();
        _userService = new(_userRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        _userRepositoryMock.Setup(r =>
            r.Get(It.IsAny<string>())).Returns
        (
            (string id) => id == "-1" ? null : _testUser
        );
    }

    [Fact]
    public void GetUser_ReturnsTestUser()
    {
        var user = _userService.GetUser("1");
        Assert.NotNull(user);
        Assert.Equal("Username", user?.UserName);
        Assert.Equal("Email", user?.Email);
        Assert.Equal("ImageUrl", user?.ImageUrl);
    }

    [Fact]
    public void GetUser_ReturnsNull()
    {
        var user = _userService.GetUser("-1");
        Assert.Null(user);
    }
}