using RecipeBook.Data.Models;

namespace RecipeBook.Business.Services;

public interface ILikeService
{
    public Like? AddLike(long userId, long recipeId);
}
