using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminPanelController : Controller
    {
        public IActionResult index()=> View();
    }
}