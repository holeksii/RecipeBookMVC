namespace RecipeBook.Business.Services;

using RecipeBook.Business.Repositories;
using RecipeBook.Data.Models;

public class LikeService : ILikeService
{
    private readonly LikeRepository repository;

    public LikeService(LikeRepository likeRepository)
    {
        repository = likeRepository;
    }

    public Like? AddLike(long userId, long recipeId)
    {
        return repository.Add(userId, recipeId);
    }
}
