using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
public class CommentService : ICommentService
{
    private readonly CommentRepository repository;
    public CommentService(CommentRepository commentRepository)
    {
        repository = commentRepository;
    }
    public Comment AddComment(long userId, long recipeId, string commentText)
    {
        return repository.Add(userId, recipeId, commentText);
    }
}
