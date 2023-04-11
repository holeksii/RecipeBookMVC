using RecipeBook.Data.Context;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Repositories;

public class CommentRepository : EfCoreRepository<Comment, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public CommentRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public CommentRepository() : this(new DatabaseContext())
    {
    }

    public virtual Comment? Add(long userId, long recipeId, string text)
    {
        Recipe? recipe = _context.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            User? user = _context.Find<User>(userId);
            if (user != null)
            {
                Comment comment = new (text, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
                user.Comments.Add(comment);
                recipe.Comments.Add(comment);
                _context.SaveChanges();
                return comment;
            }
        }
        return null;
    }
}
