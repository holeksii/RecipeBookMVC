using RecipeBook.Data.Repositories;

namespace RecipeBook.Data.Services;

using Data.Repositories;
using RecipeBook.Data.Models;

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
