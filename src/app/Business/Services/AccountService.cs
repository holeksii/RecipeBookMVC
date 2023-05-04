using System.Threading.Tasks;
using RecipeBook.Business.Models;
using RecipeBook.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Business.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    public AccountService(UserManager<User> userMenager)
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
