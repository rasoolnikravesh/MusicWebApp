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
            .ForMember(x => x.SongWriter, y => y.MapFrom(z => writer(z.IsSongWriter)))
            .ForMember(x => x.Arrangement, y => y.MapFrom(z => areng(z.IsArrengement)))
            .ForMember(x => x.Compos, y => y.MapFrom(z => comp(z.IsComposer)))
            .ForMember(x => x.RemixMusics, y => y.MapFrom(z => mix(z.IsMixAndMaster)))
            .ReverseMap();

        }

        private object mix(bool isMixAndMaster)
        {
            if (isMixAndMaster) return new MixMaster();
            else return null;
        }

        private Composer comp(bool isComposer)
        {
            if (isComposer) return new Composer();
            else return null;
        }

        private Arrangement areng(bool isArrengement)
        {
            if (isArrengement) return new Arrangement();
            else return null;
        }
    }
}