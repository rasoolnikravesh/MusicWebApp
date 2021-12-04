using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Areas.Admin.ViewModels.Artist;
using MusicWebApp.Models;
using AutoMapper;

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
        public async Task<IActionResult> AddSingerToArtistAsync(int id)
        {
            var artist = db.Artists.Include(x => x.Singer).SingleOrDefault(x => x.Id == id);
            if (artist != null)
            {
                if (artist.Singer == null)
                {
                    artist.Singer = new Models.Singer();
                    await db.SaveChangesAsync();
                    TempData["message"] = "0";
                    return RedirectToAction(nameof(Artists));
                }
                else
                {
                    TempData["message"] = "2";
                    return RedirectToAction(nameof(Artists));
                }
            }
            else
            {
                TempData["message"] = "-1";
                return RedirectToAction(nameof(Artists));
            }
        }
        [HttpGet()]
        public IActionResult InsertArtist() => View();
        [HttpPost()]
        public IActionResult InsertArtist(InsertArtistViewModel model, [FromServices] IMapper maper)
        {
            if (ModelState.IsValid)
            {
                var artist = maper.Map<Artist>(model);
                
                db.Add(artist);
                db.SaveChangesAsync();

            }
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

    }
}