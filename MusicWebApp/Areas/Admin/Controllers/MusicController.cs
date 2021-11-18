using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWebApp.Areas.Admin.ViewModels;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;
using MusicWebApp.Models.Builders;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Policy = "MusicPolicy")]
    public class MusicController : Controller
    {
        private readonly MusicAppContext context;
        public MusicController(MusicAppContext _context)
        {
            context = _context;
        }
        public IActionResult InsertMusic()
        {
            ViewData["returnurl"] = "/Panel/Music/InsertMusic";
            return View();
        }
        public async Task<IActionResult> InsertMusicConfirmAsync(InsertMusicViewModel model, string returnurl = "")
        {
            if (ModelState.IsValid)
            {
                var m = new MusicBuilder().WithName(model.Name).WithTitle(model.Title)
                .WithDate(model.Date).WithUrl128(model.url128).WithUrl320(model.url320).Build();

                await context.Musics.AddAsync(m);
                await context.SaveChangesAsync();
            }
            HttpContext.Session.SetString("returnurl", returnurl);
            return RedirectToAction("InsertMusicImage", "Music");
        }
        public IActionResult InsertMusicImage()
        {
            var returnurl = HttpContext.Session.GetString("returnurl");
            ViewData["returnurl"] = returnurl;
            return View();
        }
    }
}