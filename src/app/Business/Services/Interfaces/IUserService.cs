namespace RecipeBook.Business.Services;

using Data.Models;

public interface IUserService
{
    User? GetUser(long id);
}
