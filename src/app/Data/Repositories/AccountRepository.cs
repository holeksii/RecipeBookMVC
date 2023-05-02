using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        public AccountRepository(UserManager<User> userMenager)
        {
            _userManager = userMenager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new User()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
            };
            return await _userManager.CreateAsync(user, userModel.Password);
        }
    }
}
