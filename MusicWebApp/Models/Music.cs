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
        public int GenreId { get; set;}
        public Genre Genre { get; set; }
        public Artist Singer { get; set; }

        public Artist SongWriter { get; set; }

        public Artist Composer { get; set; }
    }
}