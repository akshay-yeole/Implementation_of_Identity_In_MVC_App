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

        [Route("login")]
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> login(SignInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var res = await repository.SignInAsync(model);
                if (res.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Creds");
            }
            return View(model);
        }

        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            await repository.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

        [Route("changepassword")]
        [HttpGet]
        public IActionResult changepassword()
        {
            return View();
        }

        [Route("changepassword")]
        [HttpPost]
        public async Task<IActionResult> changepassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var res =await repository.ChangePasswordAsync(model);
                if (res.Succeeded)
                {
                    ViewBag.NewPassword = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        } 
    }
}
