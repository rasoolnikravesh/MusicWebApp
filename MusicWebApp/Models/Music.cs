using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWebApp.Models
{
    public class Music
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Url128 { get; set; }
        public string Url320 { get; set; }
        //singer// 
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Subject> Subjects { get; set; }

        public virtual Singer Singer { get; set; }

        public virtual SongWriter SongWriter { get; set; }
        public virtual Composer Composer { get; set; }
        public virtual MixMaster MixMaster { get; set; }
        public virtual Album Album { get; set; }

    }

}
