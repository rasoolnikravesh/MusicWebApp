using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string subjectName { get; set; }
        public virtual List<Music> Musics { get; set; }
        public virtual List<Album> Albums { get; set; }

    }
}