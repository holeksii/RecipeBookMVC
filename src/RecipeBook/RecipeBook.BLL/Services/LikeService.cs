using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
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