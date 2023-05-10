using RecipeBook.Data.Repositories;

namespace RecipeBookTest.Business.Proxy;

public class RecipeRepositoryMoqProxy : RecipeRepository
{
    public RecipeRepositoryMoqProxy() : base(null!)
    {
    }
}