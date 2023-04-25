namespace RecipeBook.Data.Services;

using RecipeBook.Data.Models;

public interface IUserService
{
    public User? GetUser(long id);
}
