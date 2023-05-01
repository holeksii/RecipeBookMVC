namespace RecipeBook.Business.Services;

using Data.Models;
using Business.Models;

public interface IRecipeService
{
    List<RecipeDTO>? GetAllRecipes();

    List<RecipeDTO>? GetUserRecipes(long id);

    List<RecipeDTO>? GetLikedRecipes(long id);

    List<RecipeDTO>? GetRecipesSortedBy(string field, List<RecipeDTO> list);

    RecipeDetailsDTO? GetRecipe(long id);

    RecipeDetailsDTO? AddRecipe(long userId, RecipeDetailsDTO recipeDTO);
}
