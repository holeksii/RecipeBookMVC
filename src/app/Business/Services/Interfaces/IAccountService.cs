using System.Threading.Tasks;
using RecipeBook.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Business.Services;

public interface IAccountService
{
    Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

    Task<SignInResult> PasswordLoginAsync(LoginUserModel userModel);

    Task LogoutAsync();

    Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
}