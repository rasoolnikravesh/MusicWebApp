using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MusicWebApp.Models;

namespace MusicWebApp.Areas.Admin.ViewModels
{
    public class InsertMusicViewModel
    {
        [Required(ErrorMessage = "نام کاربری وارد نشده است")]
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Singer { get; set; }
        public string SongWriter{ get; set; }
        public string Genre { get; set; }
        public string url128 { get; set; }
        public string url320 { get; set; }
        [Required(ErrorMessage = "عکس را انتخاب کنید")]
        public IFormFile Image { get; set; }
        public string alt { get; set; }

    }
}