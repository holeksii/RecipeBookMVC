using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Data;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Repositories;
public class LikeRepository : EfCoreRepository<Like, DatabaseContext>
{
    private readonly DatabaseContext _context;
    public LikeRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    public Like Add(long userId, long recipeId)
    {
        Recipe? recipe = _context.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            User? user = _context.Find<User>(userId);
            if (user != null)
            {
                Like? previous = _context.Set<Like>().FirstOrDefault(l => l.User.Id == userId && l.Recipe.Id == recipeId);
                if (previous == null && userId != recipe.User.Id)
                {
                    Like like = new Like(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
                    user.Likes.Add(like);
                    recipe.Likes.Add(like);
                    _context.SaveChanges();
                    return like;
                }
            }
        }
        return null;
    }
}
