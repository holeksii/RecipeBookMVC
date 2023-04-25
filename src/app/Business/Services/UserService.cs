namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;

public class UserService : IUserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository userRepository)
    {
        _repository = userRepository;
    }

    public User? GetUser(long id)
    {
        return _repository.Get(id);
    }
}
