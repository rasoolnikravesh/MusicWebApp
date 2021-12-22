using AutoMapper;
using MusicWebApp.Areas.Admin.ViewModels.Artist;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;
using System;

namespace MusicWebApp.Mapers.Artists
{
    public class ShowArtistsMapperProfile : Profile
    {
        private readonly MusicAppContext db;
        public ShowArtistsMapperProfile(MusicAppContext _db)
        {
            db = _db;
            CreateMap<Artist, ShowArtistViewModel>()
                .ForMember(x => x.Bio, y => y.MapFrom(z => SetBio(z.Bio)))
                .ForMember(x => x.IsSinger, y => y.MapFrom(z => z.Singer == null ? false : true))
                .ForMember(x => x.IsSongWriter, y => y.MapFrom(z => z.SongWriter == null ? false : true))
                .ForMember(x => x.IsArrangement, y => y.MapFrom(z => z.Arrangement == null ? false : true))
                .ForMember(x => x.IsRemixMusics, y => y.MapFrom(z => z.RemixMusics == null ? false : true))
                .ForMember(x => x.IsCompos, y => y.MapFrom(z => z.Compos == null ? false : true));
        }

        private object SetBio(string bio)
        {
            if (!string.IsNullOrWhiteSpace(bio))
            {
                if (bio.Length < 100)
                    return bio;
                string str = bio.Substring(0, 100);
                return str;
            }
            else
                return bio;
        }
    }
}
