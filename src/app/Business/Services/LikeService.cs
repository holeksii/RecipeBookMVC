using RecipeBook.Data.Models;

namespace RecipeBook.Business.Services;

using Data.Repositories;

public class LikeService : ILikeService
{
    private readonly LikeRepository _likeRepository;
    private readonly RecipeRepository _recipeRepository;
    private readonly UserRepository _userRepository;

    public LikeService(LikeRepository likeRepository, RecipeRepository recipeRepository,
        UserRepository userRepository)
    {
        _likeRepository = likeRepository;
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
    }

    public bool AddLike(string userId, long recipeId)
    {
        if (_recipeRepository.GetUserLikedRecipes(userId).Any(r => r.Id == recipeId))
        {
            return false;
        }

        var now = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        var user = _userRepository.Get(userId);
        var recipe = _recipeRepository.Get(recipeId);

        if (user is null || recipe is null)
        {
            return false;
        }

        if (user.Id == recipe.User!.Id)
        {
            return false;
        }

        var like = new Like(now) { User = user, Recipe = recipe };

        _recipeRepository.Update(recipe);
        _likeRepository.Add(like);
        return true;
    }

    public bool DeleteLike(string userId, long recipeId)
    {
        var like = _likeRepository.GetPreviousLike(userId, recipeId);
        var recipe = _recipeRepository.Get(recipeId);
        if (like is null || recipe is null)
        {
            return false;
        }

        _likeRepository.Delete(like.Id);
        _recipeRepository.Update(recipe);
        return true;
    }
}