using RecipeBook.Data.Models;

namespace RecipeBook.Business.Services;

public interface ILikeService
{
    public void AddOrDeleteLike(long userId, long recipeId);
}
