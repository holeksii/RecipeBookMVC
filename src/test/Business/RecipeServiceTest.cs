using RecipeBook.Business.Models;
using RecipeBook.Data.Models;
using RecipeBookTest.Business.Proxy;

namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Services;

public sealed class RecipeServiceTest
{
    readonly Mock<RecipeRepositoryMoqProxy> _recipeRepositoryMock;
    readonly RecipeService _recipeService;

    public RecipeServiceTest()
    {
        _recipeRepositoryMock = new Mock<RecipeRepositoryMoqProxy>();
        InitMockMethods();
        _recipeService = new(_recipeRepositoryMock.Object);
    }

    void InitMockMethods()
    {
        _recipeRepositoryMock.Setup(r =>
            r.GetAll()).Returns(
            new List<Recipe>
            {
                new Recipe { Name = "Recipe 1" },
                new Recipe { Name = "Recipe 3" },
                new Recipe { Name = "Recipe 2" },
            }
        );

        _recipeRepositoryMock.Setup(r =>
            r.GetUserRecipes(It.IsAny<string>())).Returns(
            new List<Recipe>
            {
                new Recipe { Name = "Recipe 1" },
                new Recipe { Name = "Recipe 2" },
            }
        );

        _recipeRepositoryMock.Setup(r =>
            r.GetUserLikedRecipes(It.IsAny<string>())).Returns(
            new List<Recipe>
            {
                new Recipe { Name = "Recipe 1" },
            }
        );

        _recipeRepositoryMock.Setup(r =>
            r.Get(It.IsAny<long>())).Returns(
            new Recipe { Name = "Recipe 100", Instructions = "Instructions", TimeToCook = 10 }
        );

        _recipeRepositoryMock.Setup(r =>
            r.Add(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<Recipe>())).Returns(
            new Recipe { Name = "1", Instructions = "1", TimeToCook = 1 }
        );
    }

    [Fact]
    public void TestGetAllRecipes()
    {
        var recipes = _recipeService.GetAllRecipes();
        Assert.Equal(3, recipes?.Count);
    }

    [Fact]
    public void TestGetUserRecipes()
    {
        var recipes = _recipeService.GetUserRecipes("1");
        Assert.Equal(2, recipes?.Count);
    }

    [Fact]
    public void TestGetLikedRecipes()
    {
        var recipes = _recipeService.GetLikedRecipes("1");
        Assert.Equal(1, recipes?.Count);
    }

    [Fact]
    public void TestGetRecipesSortedBy()
    {
        var recipes = _recipeService.GetRecipesSortedBy("Likes", _recipeService.GetAllRecipes()!);
        Assert.Equal("Recipe 1", recipes?[0].Name);
        Assert.Equal("Recipe 3", recipes?[1].Name);
        Assert.Equal("Recipe 2", recipes?[2].Name);
    }

    [Fact]
    public void TestGetRecipe()
    {
        var recipe = _recipeService.GetRecipe(100);
        Assert.Equal("Recipe 100", recipe?.Name);
        Assert.Equal("Instructions", recipe?.Instructions);
        Assert.Equal(10, recipe?.TimeToCook);
    }

    [Fact]
    public void TestAddRecipe()
    {
        var recipe = _recipeService.AddRecipe("1", 1L,
            new RecipeDetailsDTO { Name = "1", Instructions = "1", TimeToCook = 1 });
        Assert.Equal("1", recipe?.Name);
        Assert.Equal("1", recipe?.Instructions);
        Assert.Equal(1, recipe?.TimeToCook);
    }
}