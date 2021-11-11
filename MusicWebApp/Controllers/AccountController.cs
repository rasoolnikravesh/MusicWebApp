using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Text.Json;
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
                var u = await userManager.FindByNameAsync(model.Name);
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
                if (result.Succeeded)
                {
                    TempData["LoginRegisterMessage"] = "ورود موفق";
                    return RedirectToAction(nameof(LoginRegister));

                }
                else if (result.IsLockedOut)
                {
                    TempData["LoginRegisterMessage"] = "نام کاربری شما به مدت 1 دقیقه قفل شد";
                }
                else
                {
                    TempData["LoginRegisterMessage"] = "نام کاربری یا روز ورود نا درست میباشد";
                }
                //TempData["LoginRegisterMessage"] = result.Succeeded ? "وارد شدید" : "رمز عبور نادرست است";
            }
            return RedirectToAction(nameof(LoginRegister));

        }
        public async Task<IActionResult> CheckUserNameAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
                return Json(true);
            else
                return Json(false);
        }
        public async Task<IActionResult> CheckEmailAsync(string Email)
        {
            var user = await userManager.FindByEmailAsync(email: Email);
            if (user == null)
                return Json(true);
            else
                return Json(false);
        }
        public void Logout()
        {
            signInManager.SignOutAsync();

        }
    }
}