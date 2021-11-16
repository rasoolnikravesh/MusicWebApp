using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Composer
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<Music> Musics { get; set; }
    }
}