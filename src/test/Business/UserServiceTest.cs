namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;

public class UserServiceTest
{
    static readonly Mock<UserRepository> userRepositoryMock;
    static readonly UserRepository userRepository;
    static readonly UserService userService;

    static UserServiceTest()
    {
        userRepositoryMock = new Mock<UserRepository>();
        InitMockMethods();
        userRepository = userRepositoryMock.Object;
        userService = new(userRepository);
    }

    static void InitMockMethods()
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
