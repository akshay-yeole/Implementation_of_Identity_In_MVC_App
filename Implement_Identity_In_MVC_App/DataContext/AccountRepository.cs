using Implement_Identity_In_MVC_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Implement_Identity_In_MVC_App.DataContext
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountRepository(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpModel model)
        {
            var user = new IdentityUser() { 
                Email = model.EmailId,
                UserName = model.UserName,  
                
            };
            return await userManager.CreateAsync(user,model.Password);
        }
    }
}
