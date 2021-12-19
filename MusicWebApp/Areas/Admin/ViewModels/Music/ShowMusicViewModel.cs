using System;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Areas.Admin.ViewModels.Music
{
    public class ShowMusicViewModel
    {
        public int Id { get; set; }
        [Display(Name ="نام")]
        public string Name { get; set; }
        [Display(Name = "خواننده")]
        public string SingerName { get; set; }
        public DateTime Date { get; set; }
        [Display(Name="سبک")]
        public string GenreName { get; set; }
        [Display(Name="شاعر")]
        public string SongWriterName { get; set; }
        [Display(Name="آهنگساز")]
        public string ComposerName { get; set; }

    }
}
