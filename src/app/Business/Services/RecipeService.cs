using RecipeBook.Data.Repositories;

namespace RecipeBook.Data.Services;

using Data.Repositories;
using RecipeBook.Data.Models;

public class RecipeService : IRecipeService
{
    private readonly RecipeRepository repository;

    public RecipeService(RecipeRepository recipeRepository)
    {
        repository = recipeRepository;
    }

    public List<Recipe>? GetAllRecipes()
    {
        return repository.GetAll();
    }

    public List<Recipe>? GetUserRecipes(long id)
    {
        return repository.GetUserRecipes(id);
    }

    public List<Recipe>? GetLikedRecipes(long id)
    {
        return repository.GetLikedRecipes(id);
    }

    public List<Recipe>? GetRecipesSortedBy(string field, List<Recipe> list)
    {
        return field switch
        {
            "Likes" => list.OrderByDescending(x => x.Likes.Count).ToList(),
            "Comments" => list.OrderByDescending(x => x.Comments.Count).ToList(),
            "Time" => list.OrderByDescending(x => x.TimeToCook).ToList(),
            _ => list.OrderByDescending(x => x.Id).ToList(),
        };
    }

    public Recipe? GetRecipe(long id)
    {
        return repository.Get(id);
    }

    public Recipe? AddRecipe(long userId, Recipe recipe)
    {
        if (repository.Add(userId, recipe) != null)
        {
            return recipe;
        }
        return null;
    }
}
