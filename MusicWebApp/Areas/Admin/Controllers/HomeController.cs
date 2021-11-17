using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult index()=> View();
    }
}