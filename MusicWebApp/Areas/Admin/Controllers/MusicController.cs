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
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            ViewData["genres"] = context.Genres.ToList();

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
            ViewData["singer"]= context.Singers.Include(x=> x.Artist).ToList();
            ViewData["songwriter"] = context.SongWriters.Include(x => x.Artist).ToList();
            return View();
        }

        public async Task<IActionResult> InsertMusicConfirmAsync(InsertMusicViewModel model, [FromServices] IMapper maper, string returnurl = "")
        {
            if (ModelState.IsValid)
            {
                var music = maper.Map<InsertMusicViewModel, Music>(model);
                context.Add(music);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Musics));
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
        public async Task<IActionResult> DeleteAsync(int Id)
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