using System.Threading.Tasks;
using RecipeBook.Business.Models;
using RecipeBook.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Business.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AccountService(UserManager<User> userMenager, SignInManager<User> signInManager)
    {
        _userManager = userMenager;
        _signInManager = signInManager;
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

    public async Task<SignInResult> PasswordLoginAsync(LoginUserModel userModel)
    {
        return await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
