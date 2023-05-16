using RecipeBook.Data.Repositories;

namespace RecipeBookTest.Business.Proxy;

public class UserRepositoryMoqProxy : UserRepository
{
    public UserRepositoryMoqProxy() : base(null!)
    {
    }
}