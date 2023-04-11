using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
public interface ICommentService
{
    public Comment AddComment(long userId, long recipeId, string commentText);
}
