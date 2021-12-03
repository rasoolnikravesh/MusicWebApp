using System.Linq;
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
        public IActionResult Musics()
        {
            var con = context.Musics.ToList();
            return View(con);
        }

        public IActionResult Genres()
        {
            return View();
        }
        public async Task<IActionResult> InsertGenreAsync(InsertGenreViewModel model)
        {
            var genre = context.Genres.SingleOrDefault(x => x.GenreName == model.GenreName);
            if (genre == null)
            {
                genre = new()
                {
                    GenreName = model.GenreName,
                };
            }
            else
                return RedirectToAction("Genres");
            context.Add(genre);
            await context.SaveChangesAsync();

            return RedirectToAction("Genres");

        }
        public IActionResult InsertMusic()
        {
            var Genres = context.Genres.ToList();
            ViewData["Genres"] = Genres;
            ViewData["returnurl"] = "/Panel/Music/InsertMusic";
            return View();
        }
        public async Task<IActionResult> InsertMusicConfirmAsync(InsertMusicViewModel model, string returnurl = "")
        {
            if (ModelState.IsValid)
            {
                var m = new MusicBuilder().WithName(model.Name).WithTitle(model.Title)
                .WithDate(model.Date).WithUrl128(model.url128).WithUrl320(model.url320).Build();
                var q = context.Genres.SingleOrDefault(x => x.GenreName == model.Genre);
                m.Genre = q;
                await context.Musics.AddAsync(m);
                await context.SaveChangesAsync();
                HttpContext.Session.SetInt32("MusicId", m.Id);
            }
            HttpContext.Session.SetString("returnurl", returnurl);
            return RedirectToAction("InsertMusicImage", "Music");
        }
        public IActionResult InsertMusicImage()
        {
            var returnurl = HttpContext.Session.GetString("returnurl");
            var musicid = HttpContext.Session.GetInt32("MusicId");
            ViewData["returnurl"] = returnurl;
            ViewData["musicid"] = musicid;
            return View();
        }
        public async Task<IActionResult> InsertMusicImageConfirmAsync(InsertMusicImageViewModel model, int musicid, string returnurl = "")
        {
            if (ModelState.IsValid)
            {
                byte[] img = new byte[model.image.Length];
                model.image.OpenReadStream().Read(img, 0, img.Length);

                var m = context.Musics.SingleOrDefault(x => x.Id == musicid);
                if (m != null)
                {

                    m.CoverImage = img;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Musics", "Music");
                }
                else
                {
                    TempData["Message"] = "موزیک پیدا نشد";
                    return RedirectToAction("Musics", "Music");
                }


            }
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteGenre(int Id)
        {
            // var q = context.Genres.SingleOrDefault(x => x.Id == Id);
            // if (q != null)
            // {

            //     var r = context.Genres.Remove(q);
            //     var rd = await context.SaveChangesAsync();
            // }
            return RedirectToAction("Genres");
        }
        public async Task<IActionResult> DeleteMusicAsync(int Id)
        {
            var music = context.Musics.SingleOrDefault(x => x.Id == Id);
            if (music != null)
            {
                var result = context.Remove(music);
                var r = await context.SaveChangesAsync();
            }
            return RedirectToAction("Musics");
        }
        
    }
}