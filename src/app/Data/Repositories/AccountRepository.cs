using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountRepository(UserManager<IdentityUser> userMenager)
        {
            _userManager = userMenager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
            };
            return await _userManager.CreateAsync(user, userModel.Password);
        }
    }
}
