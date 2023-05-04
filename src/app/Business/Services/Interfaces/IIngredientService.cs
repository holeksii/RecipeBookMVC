namespace RecipeBook.Business.Services;

using Data.Models;

public interface IIngredientService
{
    Ingredient? AddIngredient(long recipeId, string name, int quantity, string measure);
}