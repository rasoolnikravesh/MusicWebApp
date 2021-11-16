using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWebApp.Models
{
    public class Singer
    {
        [Key]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Music> SingleMusics { get; set; }

    }
}