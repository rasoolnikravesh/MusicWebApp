using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class MixMaster
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public virtual List<Music> RemixMusics { get; set; }
    }
}