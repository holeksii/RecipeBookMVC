namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;

public class CommentService : ICommentService
{
    private readonly CommentRepository _repository;

    public CommentService(CommentRepository commentRepository)
    {
        _repository = commentRepository;
    }

    public Comment? AddComment(string userId, long recipeId, string commentText)
    {
        return _repository.Add(userId, recipeId, commentText);
    }
}
