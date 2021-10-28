using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MusicWebApp.Areas.Identity.Data

{
    public class AspNetUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FatherName { get; set; }
    }
}