namespace RecipeBook.Data.Services;

public interface ILikeService
{
    public void AddOrDeleteLike(long userId, long recipeId);
}
