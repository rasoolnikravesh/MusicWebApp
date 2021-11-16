using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPanelController : Controller
    {
        public IActionResult index()=> View();
    }
}