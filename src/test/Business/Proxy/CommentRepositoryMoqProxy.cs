using RecipeBook.Data.Repositories;

namespace RecipeBookTest.Business.Proxy;

public class CommentRepositoryMoqProxy : CommentRepository
{
    public CommentRepositoryMoqProxy() : base(null!)
    {
    }
}