using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Arrangement
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public List<Music> Arrangements { get; set; }
        
    }
}