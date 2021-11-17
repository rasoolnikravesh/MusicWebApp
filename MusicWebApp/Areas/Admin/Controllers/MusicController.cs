using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult InsertMusic() => View();
    }
}