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
                    await userManager.CreateAsync(u, model.Password);
                    TempData["LoginRegisterMessage"] = "کاربر با موفقیت ثبت شد";
                }
                else
                {
                    TempData["LoginRegisterMessage"] = "ایمیل قبلا استفاده شده است";

                }
            }
            return RedirectToAction("LoginRegister");
        }


    }
}