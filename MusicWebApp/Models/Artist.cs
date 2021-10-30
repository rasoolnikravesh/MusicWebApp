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
        public  List<Music> SingleMusics { get; set; }
        public List<Music> SongsWrited { get; set; }
        public List<Music> SongsComposed { get; set; }
    }
}