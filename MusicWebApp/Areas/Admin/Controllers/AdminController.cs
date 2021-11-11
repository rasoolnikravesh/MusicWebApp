using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {
        public IActionResult index()=> View();
    }
}