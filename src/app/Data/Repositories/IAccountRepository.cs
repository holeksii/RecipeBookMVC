using System.Threading.Tasks;
using RecipeBook.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}