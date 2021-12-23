using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Areas.Admin.ViewModels.Music
{
    public class UpdateMusicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public string Genre { get; set; }
        public string url128 { get; set; }
        public string url320 { get; set; }
        public IFormFile? Image { get; set; }
        public bool IsChange { get; set; }
        public string alt { get; set; }
        public string Singer { get; set; }
        public string SongWriter { get; set; }
        public string Composer { get; set; }
        public string Arrengement { get; set; }
        
    }
}
