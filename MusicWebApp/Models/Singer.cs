using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Models
{
    public class Singer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public virtual List<Music> Musics { get; set; }

    }
}