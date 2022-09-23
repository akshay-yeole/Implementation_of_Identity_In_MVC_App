using Implement_Identity_In_MVC_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Implement_Identity_In_MVC_App.DataContext
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserInfo userInfo;

        public AccountRepository(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, IUserInfo _userInfo)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            userInfo = _userInfo;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.EmailId,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return await userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> SignInAsync(SignInModel model)
        {
            return await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = userInfo.getUserId();
            var user = await userManager.FindByIdAsync(userId);
            return await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
