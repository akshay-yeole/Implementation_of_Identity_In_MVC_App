using Implement_Identity_In_MVC_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Implement_Identity_In_MVC_App.DataContext
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountRepository(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpModel model)
        {
            var user = new ApplicationUser() { 
                Email = model.EmailId,
                UserName = model.UserName,  
                FirstName = model.FirstName,
                LastName = model.LastName 
            };
            return await userManager.CreateAsync(user,model.Password);
        }
    }
}
