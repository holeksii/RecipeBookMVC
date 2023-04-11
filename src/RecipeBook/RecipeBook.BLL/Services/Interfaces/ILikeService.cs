using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
public interface ILikeService
{
    public Like? AddLike(long userId, long recipeId);
}