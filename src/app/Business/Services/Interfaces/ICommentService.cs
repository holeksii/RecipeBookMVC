namespace RecipeBook.Business.Services;

using Data.Models;

public interface ICommentService
{
    Comment? AddComment(string userId, long recipeId, string commentText);

    void DeleteComment(long recipeId);
}
