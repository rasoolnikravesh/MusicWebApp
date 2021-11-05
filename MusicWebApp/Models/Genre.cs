using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public List<Music> Musics { get; set; }     
    }
}