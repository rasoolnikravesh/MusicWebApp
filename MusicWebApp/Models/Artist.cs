using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string WebSite { get; set; }

        public virtual SongWriter SongWriter { get; set; }
        public virtual Singer Singer { get; set; }
        public virtual Composer Compos { get; set; }
        public virtual MixMaster RemixMusics { get; set; }
        public virtual Arrangement Arrangement { get; set; }
    }
}