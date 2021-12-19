using AutoMapper;
using MusicWebApp.Areas.Admin.ViewModels.Music;
using System;
using System.Collections.Generic;

namespace MusicWebApp.Areas.Admin.ViewModels.Artist
{
    public class ShowSingersViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public List<string> Genres { get; set; }
        public List<ShowMusicViewModel> Musics { get; set; }

        public static implicit operator ShowSingersViewModel(List<ShowMusicViewModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
