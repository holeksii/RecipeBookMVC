namespace RecipeBook.Data.Services;

using RecipeBook.Data.Models;

public interface ICommentService
{
    public Comment? AddComment(long userId, long recipeId, string commentText);
}
