namespace RecipeBook.Data.Services;

using RecipeBook.Data.Models;

public interface IRecipeService
{
    public List<Recipe>? GetAllRecipes();

    public List<Recipe>? GetUserRecipes(long id);

    public List<Recipe>? GetLikedRecipes(long id);

    public List<Recipe>? GetRecipesSortedBy(string field, List<Recipe> list);

    public Recipe? GetRecipe(long id);

    public Recipe? AddRecipe(long userId, Recipe recipe);
}
