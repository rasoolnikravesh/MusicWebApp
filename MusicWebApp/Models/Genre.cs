using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public virtual List<Music> Musics { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}