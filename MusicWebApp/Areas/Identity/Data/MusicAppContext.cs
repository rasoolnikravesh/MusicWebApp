using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Models;
namespace MusicWebApp.Areas.Identity.Data
{
    public class MusicAppContext : IdentityDbContext<AspNetUser>
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public MusicAppContext(DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Artist>().HasMany(p=> p.SingleMusics).WithOne(b=> b.Singer);
            builder.Entity<Artist>().HasMany(p=> p.SongsWrited).WithOne(b=> b.SongWriter);
            builder.Entity<Artist>().HasMany(p=> p.SongsComposed).WithOne(b=> b.Composer);
            builder.Entity<Subject>().HasMany(s=> s.Musics).WithMany(m=> m.Subjects);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
