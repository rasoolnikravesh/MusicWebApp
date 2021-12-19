using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicWebApp.Areas.Admin.ViewModels.Artist;
using MusicWebApp.Areas.Admin.ViewModels.Music;
using MusicWebApp.Models;
using System;
using System.Collections.Generic;

namespace MusicWebApp.Mapers
{
    public class ShowSingersMapperProfile : Profile
    {

        public ShowSingersMapperProfile()
        {
            CreateMap<Singer, ShowSingersViewModel>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => $"{z.Artist.Name} {z.Artist.LastName}"))
                .ForMember(x => x.Genres, y => y.MapFrom(z => SetGenres(z.Genres)))
                .ForMember(x => x.Bio, y => y.MapFrom(z => $"{z.Artist.Bio}"))
                .ForMember(x => x.Website, y => y.MapFrom(z => $"{z.Artist.WebSite}"))
                .AfterMap((src, dest, context) =>
                {
                    foreach (var music in src.SingleMusics)
                    {
                        var mus = context.Mapper.Map<ShowMusicViewModel>(music);
                        dest.Musics = new List<ShowMusicViewModel>();
                        dest.Musics.Add(mus);

                    }
                });
        }


        private object SetGenres(List<Genre> genres)
        {
            if (genres == null || genres.Count == 0)
                return null;
            List<string> strs = new List<string>();
            foreach (var genre in genres)
            {
                strs.Add(genre.GenreName);
            }
            return strs;
        }
    }
}
