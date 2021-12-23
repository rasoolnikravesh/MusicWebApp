using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Areas.Admin.ViewModels.Music;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;
using System;
using System.Linq;
namespace MusicWebApp.Mapers.Musics
{
    public class UpdateMusicsMapperProfile : Profile
    {

        private MusicAppContext db;
        public UpdateMusicsMapperProfile(MusicAppContext _db)
        {
            db = _db;
            CreateMap<UpdateMusicViewModel, Music>()
            .ForMember(x => x.Genre, y => y.MapFrom(z => Genres(z.Genre)))
            .ForMember(x => x.Singer, y => y.MapFrom(z => setsinger(z.Singer)))
            .ForMember(x => x.SongWriter, y => y.MapFrom(z => setsongwriter(z.SongWriter)))
            .ForMember(x => x.Composer, y => y.MapFrom(z => setcomposer(z.Composer)))
            .ForMember(x => x.Arrangement, y => y.MapFrom(z => SetArrengement(z.Arrengement)))
            .ForMember(x => x.CoverImage, y => y.MapFrom(z => SetCover(z.Image, z.IsChange)));

        }

        private object SetCover(IFormFile image, bool isChange)
        {
            if (isChange)
            {
                var img = Download(image);
                return img;
            }
            else
                return null;
        }

        private object SetArrengement(string arrengement)
        {
            if (arrengement == "انتخاب کنید")
                return null;
            var id = Convert.ToInt32(arrengement.Split("-")[0]);
            var comp = db.Arrangements.SingleOrDefault(x => x.Artist.Id == id);
            if (comp != null)
                return comp;
            else
                return null;
        }

        private object setcomposer(string composer)
        {
            if (composer == "انتخاب کنید")
                return null;
            var id = Convert.ToInt32(composer.Split("-")[0]);
            var comp = db.Composers.Include(x => x.Artist).SingleOrDefault(x => x.ArtistId == id);
            if (comp != null)
                return comp;
            else
                return null;


        }

        private object setsongwriter(string songWriter)
        {
            if (songWriter == "انتخاب کنید")
                return null;
            var s = songWriter.Split("-");
            int id = int.Parse(s[0]);
            var q = db.SongWriters.SingleOrDefault(x => x.ArtistId == id);
            if (q != null)
            {
                return q;
            }
            return null;
        }

        private object setsinger(string singer)
        {
            if (singer == "انتخاب کنید")
                return null;
            var s = singer.Split("-");
            int singerid = int.Parse(s[0]);
            var q = db.Singers.SingleOrDefault(x => x.ArtistId == singerid);
            if (q != null)
            {
                return q;
            }
            return null;
        }
        private object Download(IFormFile image)
        {
            byte[] img = new byte[image.Length];
            image.OpenReadStream().Read(img, 0, img.Length);
            return img;
        }
        private object Genres(string name) => db.Genres.SingleOrDefault(x => x.GenreName == name);

    }
}

