using System; 
using System.Collections.Generic;
namespace MusicWebApp.Models

{
    public class Singer : Artist
    {
        public virtual List<Music> SingleMusics{ get; set; }
        
    }
}