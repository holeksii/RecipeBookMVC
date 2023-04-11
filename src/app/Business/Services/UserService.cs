namespace RecipeBook.Business.Services;

using RecipeBook.Business.Repositories;
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
