using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
public interface IUserService
{
    public User? GetUser(long id);
}
