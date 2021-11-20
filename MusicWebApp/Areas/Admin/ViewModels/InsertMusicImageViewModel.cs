using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MusicWebApp.Areas.Admin.ViewModels
{
    public class InsertMusicImageViewModel
    {
        [Required(ErrorMessage="عکس را انتخاب کنید")]
        public IFormFile image { get; set; }
    }
}