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
        Comment comment = new(commentText, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
        return _repository.Add(userId, recipeId, comment);
    }

    public void DeleteComment(long recipeId)
    {
        _repository.Delete(recipeId);
    }
}