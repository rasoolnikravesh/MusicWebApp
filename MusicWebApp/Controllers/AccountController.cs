using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MusicWebApp.Controllers
{

    public class AccountController : Controller
    {
        UserManager<AspNetUser> userManager;
        SignInManager<AspNetUser> signInManager;

        public AccountController(UserManager<AspNetUser> _userManager,
            SignInManager<AspNetUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult LoginRegister() => View();

        public async Task<IActionResult> RegisterAsync(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var u = await userManager.FindByEmailAsync(model.Email);
                if (u == null)
                {
                    u = new AspNetUser()
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        UserName = model.UserName,
                        Email = model.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    var r = await userManager.CreateAsync(u, model.Password);
                    TempData["LoginRegisterMessage"] = r.Succeeded ? "ok" : "error";
                    //TempData["LoginRegisterEMessage"] = r.Errors.ToString();
                }
                else
                {
                    TempData["LoginRegisterMessage"] = "ایمیل قبلا استفاده شده است";

                }
            }
            return RedirectToAction(nameof(LoginRegister));
        }

        public async Task<IActionResult> LoginAsync(LoginUserViewModel model)
        {


            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                TempData["LoginRegisterMessage"] = result.Succeeded ? "وارد شدید" : "رمز عبور نادرست است";
            }
            else
            {
                TempData["LoginRegisterMessage"] = "نام کاربری وجود ندارد";
            }

            return RedirectToAction(nameof(LoginRegister));
        }
        public void Logout()
        {
            signInManager.SignOutAsync();
            
        }
    }
}