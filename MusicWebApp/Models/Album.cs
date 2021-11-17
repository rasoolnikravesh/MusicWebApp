using System;
using System.Collections.Generic;

namespace MusicWebApp.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual Genre Genre { get; set; }
        //public Group Group { get; set; }
        public virtual Singer Singer { get; set; }
        public DateTime Created { get; set; }
        public string FullUrl { get; set; }
        public virtual List<Music> Musics { get; set; }
        public string Details { get; set; }

    }
}