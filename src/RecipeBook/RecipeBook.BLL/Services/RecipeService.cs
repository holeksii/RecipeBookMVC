using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
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
    public List<Recipe>? GetRecipesSortedBy(string field, List<Recipe> list)
    {
        if (list == null)
        {
            return list;
        }
        switch (field)
        {
            case "Likes":
                return list.OrderByDescending(x => x.Likes.Count).ToList();
            case "Comments":
                return list.OrderByDescending(x => x.Comments.Count).ToList();
            case "Time":
                return list.OrderByDescending(x => x.TimeToCook).ToList();
            default:
                return list.OrderByDescending(x => x.Id).ToList();
        }
    }
    public Recipe? GetRecipe(long id)
    {
        return repository.Get(id);
    }
    public Recipe AddRecipe(long userId, Recipe recipe)
    {
        repository.Add(userId, recipe);
        return recipe;
    }
}
