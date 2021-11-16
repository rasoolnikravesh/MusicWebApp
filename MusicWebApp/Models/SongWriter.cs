using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWebApp.Models
{
    public class SongWriter
    {
        [Key]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public string NikName { get; set; }
        public virtual List<Music> Lyrics { get; set; }
    }
}