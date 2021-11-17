using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicWebApp.Areas.Admin.ViewModels;
namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Policy = "MusicPolicy")]
    public class MusicController : Controller
    {
        public IActionResult InsertMusic() => View();
        public IActionResult InsertMusicConfirm(InsertMusicViewModel model)
        {

            return RedirectToAction("Index", "Home");
        }
    }
}