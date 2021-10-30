using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string subjectName { get; set; }
        public List<Music> Musics { get; set; }

    }
}