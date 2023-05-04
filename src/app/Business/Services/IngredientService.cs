namespace RecipeBook.Business.Services;

using RecipeBook.Data.Repositories;
using RecipeBook.Data.Models;

public class IngredientService : IIngredientService
{
    private readonly IngredientRepository _repository;

    public IngredientService(IngredientRepository ingredientRepository)
    {
        _repository = ingredientRepository;
    }

    public Ingredient? AddIngredient(long recipeId, string name, int quantity, string measure)
    {
        Ingredient ingredient = new Ingredient(name, quantity, measure);
        return _repository.Add(recipeId, ingredient);
    }
}