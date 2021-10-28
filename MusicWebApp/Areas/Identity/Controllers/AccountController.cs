using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using MusicWebApp.Areas.Identity.Data;

namespace MusicWebApp.Areas.Identity.Controllers
{
    [Area("identity")]
    public class AccountController : Controller
    {
        private readonly MusicAppContext _CONTEXT;
        public AccountController(MusicAppContext Context)
        {
            _CONTEXT = Context;
        }
        public IActionResult test()
        {

            _CONTEXT.Users.Add(new Data.AspNetUser
            {
                Name = "rasool",
                LastName = "nikravesh",
                FatherName = "alah dad",


            });
            _CONTEXT.SaveChanges();
            return View((object) _CONTEXT.Users.FirstOrDefault().ToString());
        }
    }
}