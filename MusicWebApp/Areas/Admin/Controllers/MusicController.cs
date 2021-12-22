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
using System.Collections.Generic;
using MusicWebApp.Areas.Admin.ViewModels.Music;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Policy = "MusicPolicy")]
    public class MusicController : Controller
    {
        private readonly MusicAppContext db;
        public MusicController(MusicAppContext _db)
        {
            db = _db;
        }
        public IActionResult Musics([FromServices] IMapper mapper)
        {
            var musics = db.Musics
                .ToList();
            List<ShowMusicViewModel> list = new List<ShowMusicViewModel>();
            foreach (var item in musics)
            {
                var musicmodel = mapper.Map<ShowMusicViewModel>(item);
                list.Add(musicmodel);
            }
            return View(list);
        }

        public IActionResult Genres()
        {
            ViewData["genres"] = db.Genres.ToList();

            return View();
        }
        public async Task<IActionResult> InsertGenreAsync(InsertGenreViewModel model)
        {
            var genre = db.Genres.SingleOrDefault(x => x.GenreName == model.GenreName);
            if (genre == null)
            {
                genre = new()
                {
                    GenreName = model.GenreName,
                };
            }
            else
                return RedirectToAction("Genres");
            db.Add(genre);
            await db.SaveChangesAsync();

            return RedirectToAction("Genres");

        }

        public IActionResult InsertMusic()
        {
            var Genres = db.Genres.ToList();
            ViewData["Genres"] = Genres;
            ViewData["singer"] = db.Singers.ToList();
            ViewData["songwriter"] = db.SongWriters.ToList();
            ViewData["composer"] = db.Composers.ToList();
            ViewData["arrengment"] = db.Arrangements.ToList();
            return View();
        }

        public async Task<IActionResult> InsertMusicConfirmAsync(InsertMusicViewModel model, [FromServices] IMapper maper, string returnurl = "")
        {
            if (ModelState.IsValid)
            {
                var music = maper.Map<InsertMusicViewModel, Music>(model);
                db.Add(music);
                await db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Musics));
        }

        public IActionResult DeleteGenre(int Id)
        {
            // var q = db.Genres.SingleOrDefault(x => x.Id == Id);
            // if (q != null)
            // {

            //     var r = db.Genres.Remove(q);
            //     var rd = await db.SaveChangesAsync();
            // }
            return RedirectToAction("Genres");
        }
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var music = db.Musics.SingleOrDefault(x => x.Id == Id);
            if (music != null)
            {
                var result = db.Remove(music);
                var r = await db.SaveChangesAsync();
            }
            return RedirectToAction("Musics");
        }
        public List<Artist> SortArtists(string sortname)
        {
            if (sortname == "همه")
            {
                return db.Artists.ToList();
            }
            else if (sortname == "خواننده ها")
            {
                return db.Artists.Include(x => x.Singer).Where(x => x.Singer != null).ToList();
            }
            else
            {
                return null;
            }
        }
        [HttpGet()]
        public async Task<IActionResult> UpdateAsync(int Id)
        {
            var music = await db.Musics.SingleOrDefaultAsync(x => x.Id == Id);
            if (music != null)
            {
                ViewData["music"] = music;
                ViewData["Genres"] = db.Genres.ToList();
                ViewData["singer"] = db.Singers.ToList();
                ViewData["songwriter"] = db.SongWriters.ToList();
                ViewData["composer"] = db.Composers.ToList();
                ViewData["arrengment"] = db.Arrangements.ToList();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Musics));
            }
        }
        public IActionResult Update(UpdateMusicViewModel model, [FromServices] IMapper mapper)
        {
            return RedirectToAction(nameof(Musics));
        }

    }
}