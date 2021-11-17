using System;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Areas.Admin.ViewModels
{
    public class InsertMusicViewModel
    {
        [Required(ErrorMessage="نام کاربری وارد نشده است")]
        public string Name { get; set; }
        
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string url128 { get; set; }
        [Required]
        public string url320 { get; set; }

    }
}