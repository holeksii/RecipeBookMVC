namespace RecipeBook.Business.Services;

using Business.Models;

public interface IUserService
{
    UserDTO? GetUser(string id);
}
