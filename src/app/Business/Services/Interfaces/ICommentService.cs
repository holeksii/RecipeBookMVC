namespace RecipeBook.Business.Services;

using Data.Models;

public interface ICommentService
{
    Comment? AddComment(long userId, long recipeId, string commentText);
}
