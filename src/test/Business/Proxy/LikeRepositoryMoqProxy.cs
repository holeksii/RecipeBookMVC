using RecipeBook.Data.Repositories;

namespace RecipeBookTest.Business.Proxy;

public class LikeRepositoryMoqProxy : LikeRepository
{
    public LikeRepositoryMoqProxy() : base(null!)
    {
    }
}