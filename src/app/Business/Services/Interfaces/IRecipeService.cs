namespace RecipeBook.Business.Services;

using Data.Models;
using Business.Models;

public interface IRecipeService
{
    List<RecipeDTO>? GetAllRecipes();

    List<RecipeDTO>? GetUserRecipes(string id);

    List<RecipeDTO>? GetLikedRecipes(string id);

    List<RecipeDTO>? GetRecipesSortedBy(string field, List<RecipeDTO> list);

    RecipeDetailsDTO? GetRecipe(long id);

    RecipeDetailsDTO? AddRecipe(string userId, long categoryId, RecipeDetailsDTO recipeDTO);
}
