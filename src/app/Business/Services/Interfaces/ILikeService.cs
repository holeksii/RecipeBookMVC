using RecipeBook.Data.Models;

namespace RecipeBook.Business.Services;

public interface ILikeService
{
    bool AddLike(string userId, long recipeId);

    bool DeleteLike(string userId, long recipeId);
}
