using System;
using System.ComponentModel.DataAnnotations;
using MusicWebApp.Models;

namespace MusicWebApp.Areas.Admin.ViewModels
{
    public class InsertMusicViewModel
    {
        [Required(ErrorMessage="نام کاربری وارد نشده است")]
        public string Name { get; set; }
        
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        [Required]
        public string url128 { get; set; }
        public string url320 { get; set; }

    }
}