using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.BLL.Services
{
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
}
