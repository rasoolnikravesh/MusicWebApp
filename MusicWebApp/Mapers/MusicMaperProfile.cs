using System;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWebApp.Areas.Admin.ViewModels;
using MusicWebApp.Areas.Identity.Data;
using MusicWebApp.Models;

namespace MusicWebApp.Mapers
{
    public class MusicMaperProfile : Profile
    {
        private MusicAppContext db;
        public MusicMaperProfile(MusicAppContext _db)
        {
            db = _db;
            CreateMap<InsertMusicViewModel, Music>()
            .ForMember(x => x.CoverImage, y => y.MapFrom(z => Download(z.Image)))
            .ForMember(x => x.Genre, y => y.MapFrom(z => Genres(z.Genre)));
        }
        private object Genres(string name) => db.Genres.SingleOrDefault(x => x.GenreName == name);


        private object Download(IFormFile image)
        {
            byte[] img = new byte[image.Length];
            image.OpenReadStream().Read(img, 0, img.Length);
            return img;
        }
    }
}