using AutoMapper;
using MusicWebApp.Areas.Admin.ViewModels.Music;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;
using System;

namespace MusicWebApp.Mapers
{
    public class ShowMusicMaperProfile : Profile
    {
        private readonly MusicAppContext db;
        public ShowMusicMaperProfile(MusicAppContext _db)
        {
            db = _db;
            CreateMap<Music, ShowMusicViewModel>()
                .ForMember(x => x.SingerName, y => y.MapFrom(z => setSingerName(z.Singer)))
                .ForMember(x => x.SongWriterName, y => y.MapFrom(z => setSongWriteName(z.SongWriter)))
                .ForMember(x => x.GenreName, y => y.MapFrom(z => SetGenreName(z.Genre)))
                .ForMember(x => x.ComposerName, y => y.MapFrom(z => SetComposerName(z.Composer)))
                ;
        }

        private object SetComposerName(Composer composer)
        {
            if (composer == null)
                return null;
            return null;
        }

        private object SetGenreName(Genre genre)
        {
            if (genre == null)
                return null;
            else
            {
                var name = $"{genre.GenreName}";
                return name;
            }
        }

        private object setSongWriteName(SongWriter songWriter)
        {
            if (songWriter == null)
                return null;
            else
            {
                var name = $"{songWriter.Artist.Name} {songWriter.Artist.LastName}";
                return name;
            }
        }

        private object setSingerName(Singer singer)
        {
            
            if (singer == null)
                return null;
            else
            {
                var name = $"{singer.Artist.Name} {singer.Artist.LastName}";
                return name;
            }
        }
    }
}
