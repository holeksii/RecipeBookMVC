using Moq;
using RecipeBook.Business.Services;
using RecipeBook.Data.Models;
using RecipeBook.Data.Repositories;
using RecipeBookTest.Business.Proxy;

namespace RecipeBookTest.Business;

public class IngredientServiceTest
{
    readonly Mock<IngredientRepositoryMoqProxy> _ingredientRepositoryMock;
    readonly IngredientService _ingredientService;

    readonly long _wrongRecipeId;

    readonly Ingredient _testIngredient = new("Test", 1, "Test");

    public IngredientServiceTest()
    {
        _ingredientRepositoryMock = new Mock<IngredientRepositoryMoqProxy>();
        _wrongRecipeId = -1L;

        InitMockMethods();
        _ingredientService = new IngredientService(_ingredientRepositoryMock.Object);
    }

    private void InitMockMethods()
    {
        _ingredientRepositoryMock
            .Setup(r => r.Add(It.IsAny<long>(), It.IsAny<Ingredient>()))
            .Returns((long recipeId, Ingredient ingredient) =>
                recipeId == _wrongRecipeId ? null : ingredient);
    }
    
    [Fact]
    public void AddIngredient_WithWrongRecipeId_ReturnsNull()
    {
        const string name = "Test";
        const int quantity = 1;
        const string measure = "Test";
        
        var result = _ingredientService.AddIngredient(_wrongRecipeId, name, quantity, measure);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void AddIngredient_WithCorrectRecipeId_ReturnsIngredient()
    {
        const string name = "Test";
        const int quantity = 1;
        const string measure = "Test";
        
        var result = _ingredientService.AddIngredient(1L, name, quantity, measure);
        
        Assert.NotNull(result);
        Assert.Equal(name, result!.Name);
        Assert.Equal(quantity, result.Quantity);
        Assert.Equal(measure, result.Measure);
    }
}