using RecipeBook.Business.Services;
using RecipeBook.Data.Repositories;

namespace RecipeBookTest.Business.Proxy;

public class IngredientRepositoryMoqProxy : IngredientRepository
{
    public IngredientRepositoryMoqProxy() : base(null!)
    {
    }
}