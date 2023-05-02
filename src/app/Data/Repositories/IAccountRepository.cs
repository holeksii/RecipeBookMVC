using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}