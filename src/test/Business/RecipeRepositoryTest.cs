namespace RecipeBookTest.Business;

using Moq;
using RecipeBook.Business.Repositories;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;

public class RecipeServiceTest
{
    static readonly Mock<RecipeRepository> recipeRepositoryMock;
    static readonly RecipeRepository recipeRepository;
    static readonly RecipeService recipeService;

    static RecipeServiceTest()
    {
        recipeRepositoryMock = new Mock<RecipeRepository>();
        InitMockMethods();
        recipeRepository = recipeRepositoryMock.Object;
        recipeService = new(recipeRepository);
    }

    static void InitMockMethods()
    {
        recipeRepositoryMock.Setup(r =>
                r.GetAll()).Returns(
                    new List<Recipe>
                    {
                        new Recipe { Name = "Recipe 1" },
                        new Recipe { Name = "Recipe 3" },
                        new Recipe { Name = "Recipe 2" },
                    }
                );

        recipeRepositoryMock.Setup(r =>
                r.GetUserRecipes(It.IsAny<long>())).Returns(
                    new List<Recipe>
                    {
                        new Recipe { Name = "Recipe 1" },
                        new Recipe { Name = "Recipe 2" },
                    }
                );

        recipeRepositoryMock.Setup(r =>
                r.GetLikedRecipes(It.IsAny<long>())).Returns(
                    new List<Recipe>
                    {
                        new Recipe { Name = "Recipe 1" },
                    }
                );

        recipeRepositoryMock.Setup(r =>
                r.Get(It.IsAny<long>())).Returns(
                    new Recipe { Name = "Recipe 100", Instructions = "Instructions", TimeToCook = 10 }
                );

        recipeRepositoryMock.Setup(r =>
                r.Add(It.IsAny<long>(), It.IsAny<Recipe>())).Returns(
                    new Recipe { Name = "1", Instructions = "1", TimeToCook = 1 }
                );
    }

    [Fact]
    public void TestGetAllRecipes()
    {
        var recipes = recipeService.GetAllRecipes();
        Assert.Equal(3, recipes?.Count);
    }

    [Fact]
    public void TestGetUserRecipes()
    {
        var recipes = recipeService.GetUserRecipes(1);
        Assert.Equal(2, recipes?.Count);
    }

    [Fact]
    public void TestGetLikedRecipes()
    {
        var recipes = recipeService.GetLikedRecipes(1);
        Assert.Equal(1, recipes?.Count);
    }

    [Fact]
    public void TestGetRecipesSortedBy()
    {
        var recipes = recipeService.GetRecipesSortedBy("Likes", recipeService.GetAllRecipes()!);
        Assert.Equal("Recipe 1", recipes?[0].Name);
        Assert.Equal("Recipe 3", recipes?[1].Name);
        Assert.Equal("Recipe 2", recipes?[2].Name);
    }

    [Fact]
    public void TestGetRecipe()
    {
        var recipe = recipeService.GetRecipe(100);
        Assert.Equal("Recipe 100", recipe?.Name);
        Assert.Equal("Instructions", recipe?.Instructions);
        Assert.Equal(10, recipe?.TimeToCook);
    }

    [Fact]
    public void TestAddRecipe()
    {
        var recipe = recipeService.AddRecipe(1, new Recipe { Name = "1", Instructions = "1", TimeToCook = 1 });
        Assert.Equal("1", recipe?.Name);
        Assert.Equal("1", recipe?.Instructions);
        Assert.Equal(1, recipe?.TimeToCook);
    }
}
