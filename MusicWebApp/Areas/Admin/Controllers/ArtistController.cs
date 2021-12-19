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

        public IActionResult Artists([FromServices]IMapper mapper)
        {
            var r = db.Artists.ToList();
            List<ShowArtistViewModel> list = new List<ShowArtistViewModel>();
            foreach (var artist in r)
            {
                var res= mapper.Map<ShowArtistViewModel>(artist);
                list.Add(res);
            }
            return View(list);
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
            var d = await db.Artists.SingleOrDefaultAsync(x => x.Id == id);
            ViewData["Data"] = d;
            return View();
        }
        public async Task<IActionResult> UpdateAsync(UpdateArtistViewModel model, [FromServices] IMapper mapper)
        {
            var artist = await db.Artists.SingleOrDefaultAsync(x => x.Id == model.Id);
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
            var singers = db.Singers.ToList();
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