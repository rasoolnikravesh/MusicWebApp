using System;
using Microsoft.AspNetCore.Identity;

namespace MusicWebApp.Areas.Identity.Data

{
    public class AspNetUser:IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }
    }
}