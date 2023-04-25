namespace RecipeBook.Data.Repositories;

using Context;
using Models;

public class LikeRepository : EfCoreRepository<Like, DatabaseContext>
{
    public LikeRepository(DatabaseContext context) : base(context)
    {
    }
}
