namespace RecipeBook.Data.Repositories;

using Context;
using Models;

public class CommentRepository : EfCoreRepository<Comment, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public CommentRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public virtual Comment? Add(string uid, long recipeId, Comment comment)
    {
        var recipe = _context.Find<Recipe>(recipeId);
        if (recipe == null)
        {
            return null;
        }

        var user = _context.Find<User>(uid);
        if (user == null)
        {
            return null;
        }

        user.Comments.Add(comment);
        recipe.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }
}
