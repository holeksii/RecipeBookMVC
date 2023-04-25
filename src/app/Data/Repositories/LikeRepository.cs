using Microsoft.EntityFrameworkCore;
using RecipeBook.Data.Context;
using RecipeBook.Data.Models;

namespace RecipeBook.Data.Repositories;

public class LikeRepository : EfCoreRepository<Like, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public LikeRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public LikeRepository() : this(new DatabaseContext())
    {
    }

    public virtual void AddOrDelete(long userId, long recipeId)
    {
        Recipe? recipe = _context.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            User? user = _context.Find<User>(userId);
            if (user != null && userId != recipe.User?.Id)
            {
                Like? previous = _context.Set<Like>().Include(l => l.User).Include(l => l.Recipe).FirstOrDefault(l => l.User!.Id == userId && l.Recipe!.Id == recipeId);
                if (previous == null)
                {
                    Like like = new (DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
                    user.Likes.Add(like);
                    recipe.Likes.Add(like);
                }
                else
                {
                    _context.Remove(previous);
                }
                _context.SaveChanges();
            }
        }
    }
}
