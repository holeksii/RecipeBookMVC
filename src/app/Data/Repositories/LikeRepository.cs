namespace RecipeBook.Data.Repositories;
using Microsoft.EntityFrameworkCore;

using Context;
using Models;

public class LikeRepository : EfCoreRepository<Like, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public LikeRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    public Like? GetPreviousLike(string userId, long recipeId)
    {
        return _context.Set<Like>().Include(l => l.User).Include(l => l.Recipe).FirstOrDefault(l => l.User!.Id == userId && l.Recipe!.Id == recipeId);
    }
}
