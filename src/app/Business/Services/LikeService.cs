namespace RecipeBook.Business.Services;

using RecipeBook.Business.Repositories;

public class LikeService : ILikeService
{
    private readonly LikeRepository repository;

    public LikeService(LikeRepository likeRepository)
    {
        repository = likeRepository;
    }

    public void AddOrDeleteLike(long userId, long recipeId)
    {
        repository.AddOrDelete(userId, recipeId);
    }
}
