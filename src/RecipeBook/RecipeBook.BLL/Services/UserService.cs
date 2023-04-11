using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services;
public class UserService : IUserService
{
    private readonly UserRepository repository;
    public UserService(UserRepository userRepository)
    {
        repository = userRepository;
    }

    public User? GetUser(long id)
    {
        return repository.Get(id);
    }
}
