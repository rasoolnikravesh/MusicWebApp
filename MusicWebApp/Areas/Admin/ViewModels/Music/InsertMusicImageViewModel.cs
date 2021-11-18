using Microsoft.AspNetCore.Http;

namespace MusicWebApp.Areas.Admin.ViewModels.Music
{
    public class InsertMusicImageViewModel
    {
        public IFormFile image { get; set; }
    }
}