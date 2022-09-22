using Implement_Identity_In_MVC_App.DataContext;
using Implement_Identity_In_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Implement_Identity_In_MVC_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository repository;

        public AccountController(IAccountRepository _repository)
        {
            repository = _repository;
        }
        [Route("signup")]
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> signup(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await repository.CreateUserAsync(model);
                if (res.Succeeded)
                {
                    ModelState.Clear();
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }                  
            }
            return View();
        }
    }
}
