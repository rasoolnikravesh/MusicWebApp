using System;
using AutoMapper;
using MusicWebApp.Models;
using MusicWebApp.ViewModels;
using MusicWebApp.Areas.Admin.ViewModels;
using MusicWebApp.Areas.Admin.ViewModels.Artist;


namespace MusicWebApp.Mapers
{
    public class MuiscAppMaperProfile : Profile
    {
        private Singer singer(bool issinger)
        {
            if (issinger)
            {
                return new Singer();
            }
            else
                return null;
        }
        private SongWriter writer(bool isSong)
        {
            if (isSong)
                return new SongWriter();
            else
                return null;
        }
        public MuiscAppMaperProfile()
        {
            CreateMap<InsertArtistViewModel, Artist>()
            .ForMember(x => x.Singer, y => y.MapFrom(z => singer(z.IsSinger)))
            .ForMember(x => x.SongWriter, y => y.MapFrom(z => writer(z.IsSongWriter)));

        }
    }
}