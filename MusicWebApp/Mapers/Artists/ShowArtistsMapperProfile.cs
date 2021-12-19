using AutoMapper;
using MusicWebApp.Areas.Admin.ViewModels.Artist;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;

namespace MusicWebApp.Mapers.Artists
{
    public class ShowArtistsMapperProfile : Profile
    {
        private readonly MusicAppContext db;
        public ShowArtistsMapperProfile(MusicAppContext _db)
        {
            db = _db;
            CreateMap<Artist, ShowArtistViewModel>()
                .ForMember(x => x.Bio, y => y.MapFrom(z => z.Bio != null ? z.Bio.Substring(0, 100) : null))
                .ForMember(x => x.IsSinger, y => y.MapFrom(z => z.Singer == null ? false : true))
                .ForMember(x => x.IsSongWriter, y => y.MapFrom(z => z.SongWriter == null ? false : true))
                .ForMember(x => x.IsArrangement, y => y.MapFrom(z => z.Arrangement == null ? false : true))
                .ForMember(x => x.IsRemixMusics, y => y.MapFrom(z => z.RemixMusics == null ? false : true))
                .ForMember(x => x.IsCompos, y => y.MapFrom(z => z.Compos == null ? false : true));
        }
    }
}
