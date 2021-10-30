using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.Models
{
    public class Music
    {
        
        public int Id { get; set; }
        public string Name { get; set; }    

        public string Title { get; set; }

        public string Url128 { get; set; }      
        public string Url320 { get; set; }     
        public Singer Singer { get; set;} 
    }
}