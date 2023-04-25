namespace RecipeBook.Business.Services;

using Data.Models;

public interface IRecipeService
{
    List<Recipe>? GetAllRecipes();

    List<Recipe>? GetUserRecipes(long id);

    List<Recipe>? GetLikedRecipes(long id);

    List<Recipe>? GetRecipesSortedBy(string field, List<Recipe> list);

    Recipe? GetRecipe(long id);

    Recipe? AddRecipe(long userId, Recipe recipe);
}
