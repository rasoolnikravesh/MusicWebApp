using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Arrangement
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<Music> Arrangements { get; set; }
        
    }
}