using Moq;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;
using RecipeBookTest.Business.Proxy;

namespace RecipeBookTest.Business;

public sealed class LikeServiceTest
{
    readonly Mock<LikeRepositoryMoqProxy> _likeRepositoryMock;
    readonly Mock<RecipeRepositoryMoqProxy> _recipeRepositoryMock;
    readonly Mock<UserRepositoryMoqProxy> _userRepositoryMock;
    readonly LikeService _likeService;

    readonly long _wrongLikeId;
    readonly string _wrongUserId;
    readonly long _wrongRecipeId;

    static readonly DateTime _testDate = new(2023, 06, 20);

    readonly Like _testLike = new(_testDate);

    static readonly User _testUser = new()
    {
        UserName = "Username",
        Email = "Email",
        ImageUrl = "ImageUrl",
    };
    
    readonly Recipe _testRecipe = new()
    {
        Name = "Recipe 1",
        Instructions = "Instructions1",
        TimeToCook = 10,
        ImageUrl = "Test1",
        Category = new Category("Test1"),
        User = _testUser,
    };

    public LikeServiceTest()
    {
        _likeRepositoryMock = new Mock<LikeRepositoryMoqProxy>();
        _recipeRepositoryMock = new Mock<RecipeRepositoryMoqProxy>();
        _userRepositoryMock = new Mock<UserRepositoryMoqProxy>();
        _wrongLikeId = -1L;
        _wrongUserId = "-1";
        _wrongRecipeId = -1L;


        InitMockMethods();
        _likeService = new LikeService(_likeRepositoryMock.Object, _recipeRepositoryMock.Object,
            _userRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        _likeRepositoryMock
            .Setup(r => r.Add(It.IsAny<Like>()))
            .Returns((Like like) => like.Id == _wrongLikeId ? null : like);

        _recipeRepositoryMock
            .Setup(r => r.GetUserLikedRecipes(It.IsAny<string>()))
            .Returns(new List<Recipe> { _testRecipe });

        _recipeRepositoryMock.Setup(r => r.Get(It.IsAny<long>()))
            .Returns((long id) => id == _wrongRecipeId ? null : _testRecipe);

        _userRepositoryMock
            .Setup(r => r.Get(It.IsAny<string>()))
            .Returns((string uid) => uid == _wrongUserId ? null : _testUser);
    }

    [Fact]
    public void AddLike_WrongUid_ReturnsFalse()
    {
        var result = _likeService.AddLike(_wrongUserId, _testRecipe.Id);
        Assert.False(result);
    }

    [Fact]
    public void AddLike_WrongRecipeId_ReturnsFalse()
    {
        var result = _likeService.AddLike(_testUser.Id, _wrongRecipeId);
        Assert.False(result);
    }

    [Fact]
    public void AddLike_UserAlreadyLikedRecipe_ReturnsFalse()
    {
        var result = _likeService.AddLike(_testUser.Id, _testRecipe.Id);
        Assert.False(result);
    }

    [Fact]
    public void AddLike_RecipeOwnerLikesOwnRecipe_ReturnsTrue()
    {
        _recipeRepositoryMock.Setup(r => r.GetUserLikedRecipes(It.IsAny<string>()))
            .Returns(new List<Recipe>());

        var result = _likeService.AddLike(_testUser.Id, _testRecipe.Id);
        Assert.True(result);
    }

    [Fact]
    public void AddLike_ValidData_ReturnsTrue()
    {
        _recipeRepositoryMock.Setup(r => r.GetUserLikedRecipes(It.IsAny<string>()))
            .Returns(new List<Recipe>());

        var result = _likeService.AddLike(_testUser.Id, _testRecipe.Id);
        Assert.True(result);
    }

    [Fact]
    public void AddLike_ValidData_AddsLike()
    {
        _recipeRepositoryMock.Setup(r => r.GetUserLikedRecipes(It.IsAny<string>()))
            .Returns(new List<Recipe>());

        _likeService.AddLike(_testUser.Id, _testRecipe.Id);
        _likeRepositoryMock.Verify(r => r.Add(It.IsAny<Like>()), Times.Once);
    }

    [Fact]
    public void AddLike_ValidData_AddsLikeToRecipe()
    {
        _recipeRepositoryMock.Setup(r => r.GetUserLikedRecipes(It.IsAny<string>()))
            .Returns(new List<Recipe>());

        _likeService.AddLike(_testUser.Id, _testRecipe.Id);
        _recipeRepositoryMock.Verify(r => r.Update(It.IsAny<Recipe>()), Times.Once);
    }
}