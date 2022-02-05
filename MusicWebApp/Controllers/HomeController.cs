using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;

namespace MusicWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicAppContext db;
        public HomeController(MusicAppContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewData["musics"] = db.Musics.ToList();
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
