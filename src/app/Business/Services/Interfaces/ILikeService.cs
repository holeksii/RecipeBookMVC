using RecipeBook.Data.Models;

namespace RecipeBook.Business.Services;

public interface ILikeService
{
    bool AddLike(long userId, long recipeId);
    bool DeleteLike(long userId, long recipeId);
}
