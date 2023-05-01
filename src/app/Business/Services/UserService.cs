namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;
using Business.Models;
using AutoMapper;

public class UserService : IUserService
{
    private readonly UserRepository _repository;
    private readonly Mapper _mapper;

    public UserService(UserRepository userRepository)
    {
        _repository = userRepository;
        var configuration = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>().ConvertUsing(u => UserDTO.mapUser(u)));
        _mapper = new Mapper(configuration);
    }

    public UserDTO? GetUser(long id)
    {
        var user = _repository.Get(id);
        if (user != null)
        {
            return _mapper.Map<UserDTO>(user);
        }
        return null;
    }
}
