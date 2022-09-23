using Implement_Identity_In_MVC_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Implement_Identity_In_MVC_App.DataContext
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpModel model);
        Task<SignInResult> SignInAsync(SignInModel model);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    }
}