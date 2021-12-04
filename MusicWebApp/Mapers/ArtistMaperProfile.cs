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
        private Singer singer(bool issinger) => (issinger) ? new Singer() : null;
        private SongWriter writer(bool isSong) => (isSong) ? new SongWriter() : null;
        private object mix(bool isMixAndMaster) => (isMixAndMaster) ? new MixMaster() : null;
        private Composer comp(bool isComposer) => (isComposer) ? new Composer() : null;
        private Arrangement areng(bool isArrengement) => (isArrengement) ? new Arrangement() : null;
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

    }
}