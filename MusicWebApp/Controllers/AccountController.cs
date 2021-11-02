using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.ViewModels;

namespace MusicWebApp.Controllers
{

    public class AccountController : Controller
    {
        private readonly MusicAppContext _CONTEXT;
        
        public IActionResult LoginRegister() => View();

        public IActionResult Register(RegisterUserViewModel model)
        {

            return RedirectToAction("LoginRegister");
        }
        

    }
}