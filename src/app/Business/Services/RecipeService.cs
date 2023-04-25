namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;

public class RecipeService : IRecipeService
{
    private readonly RecipeRepository _repository;

    public RecipeService(RecipeRepository recipeRepository)
    {
        _repository = recipeRepository;
    }

    public List<Recipe>? GetAllRecipes()
    {
        return _repository.GetAll();
    }

    public List<Recipe>? GetUserRecipes(long id)
    {
        return _repository.GetUserRecipes(id);
    }

    public List<Recipe>? GetLikedRecipes(long id)
    {
        return _repository.GetUserLikedRecipes(id);
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
        return _repository.Get(id);
    }

    public Recipe? AddRecipe(long userId, Recipe recipe)
    {
        return _repository.Add(userId, recipe) is not null ? recipe : null;
    }
}
