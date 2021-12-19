using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Areas.Admin.ViewModels.Artist;
using MusicWebApp.Models;
using AutoMapper;
using MusicWebApp.Mapers;
using System.Collections.Generic;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Policy = "MusicPolicy")]
    public class ArtistController : Controller
    {
        private readonly MusicAppContext db;
        public ArtistController(MusicAppContext Context)
        {
            db = Context;
        }

        public IActionResult Artists()
        {
            var r = db.Artists.ToList();
            return View(r);
        }

        [HttpGet()]
        public IActionResult InsertArtist() => View();
        [HttpPost()]
        public async Task<IActionResult> InsertArtistAsync(InsertArtistViewModel model, [FromServices] IMapper maper)
        {
            if (ModelState.IsValid)
            {
                var artist = maper.Map<InsertArtistViewModel, Artist>(model);
                db.Add(artist);
                await db.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Artists));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var d = await db.Artists.Include(x => x.Singer)
            .Include(x => x.Arrangement).Include(x => x.Compos)
            .Include(x => x.SongWriter).Include(x => x.RemixMusics)
            .SingleOrDefaultAsync(x => x.Id == id);
            ViewData["Data"] = d;
            return View();
        }
        public async Task<IActionResult> UpdateAsync(UpdateArtistViewModel model, [FromServices] IMapper mapper)
        {
            var artist = await db.Artists.Include(x => x.Singer)
            .Include(x => x.Arrangement).Include(x => x.Compos)
            .Include(x => x.SongWriter).Include(x => x.RemixMusics)
            .SingleOrDefaultAsync(x => x.Id == model.Id);

            var res = mapper.Map<Artist>(model);
            artist.Name = res.Name;
            artist.Singer = res.Singer;
            artist.LastName = res.LastName;
            artist.Bio = res.Bio;
            artist.WebSite = res.WebSite;
            artist.RemixMusics = res.RemixMusics;
            artist.SongWriter = res.SongWriter;
            artist.Compos = res.Compos;
            artist.Arrangement = res.Arrangement;

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Artists));
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var res = db.Artists.SingleOrDefault(x => x.Id == id);
            if (res != null)
            {
                db.Remove(res);
                await db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Artists));
        }
        public IActionResult Singers([FromServices] IMapper mapper)
        {
            var singers = db.Singers.Include(x => x.Artist)
                 .ToList();
            List<ShowSingersViewModel> list = new List<ShowSingersViewModel>();
            foreach (var singer in singers)
            {
                var resualt = mapper.Map<ShowSingersViewModel>(singer);
                list.Add(resualt);
            }

            return View(list);
        }

    }
}