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

        public MusicAppContext(DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Subject>().HasMany(s => s.Musics).WithMany(m => m.Subjects);
            //songwriter table 
            builder.Entity<SongWriter>().HasKey(k => k.ArtistId);
            builder.Entity<SongWriter>().HasOne<Artist>(s => s.Artist)
            .WithOne(a => a.SongWriter).HasForeignKey<SongWriter>(s => s.ArtistId);
            builder.Entity<SongWriter>().HasMany<Music>(s => s.Lyrics).WithOne(m => m.SongWriter);
            //Singer table
            builder.Entity<Singer>().HasKey(k => k.ArtistId);
            builder.Entity<Singer>().HasOne<Artist>(s => s.Artist)
            .WithOne(a => a.Singer).HasForeignKey<Singer>(s => s.ArtistId);

            builder.Entity<Singer>().HasMany<Music>(s => s.SingleMusics)
            .WithOne(m => m.Singer);
            //Composer Table
            builder.Entity<Composer>().HasKey(k => k.ArtistId);
            builder.Entity<Composer>().HasOne<Artist>(s => s.Artist)
            .WithOne(a => a.Compos).HasForeignKey<Composer>(c => c.ArtistId);

            builder.Entity<Composer>().HasMany<Music>(c => c.Musics)
            .WithOne(m => m.Composer);
            //mixmaster
            builder.Entity<MixMaster>().HasKey(k => k.ArtistId);
            builder.Entity<MixMaster>().HasOne<Artist>(m => m.Artist)
            .WithOne(a => a.RemixMusics).HasForeignKey<MixMaster>(m => m.ArtistId);
            builder.Entity<MixMaster>().HasMany<Music>(m=> m.RemixMusics).WithOne(x=>x.MixMaster);
            //album table 
            builder.Entity<Album>().HasKey(k => k.Id);

            builder.Entity<Album>().HasMany<Music>(a=> a.Musics)
            .WithOne(m=>m.Album);
            builder.Entity<Album>().HasMany<Subject>(a=> a.Subjects)
            .WithMany(s=> s.Albums);
            builder.Entity<Album>().HasOne<Genre>(a=> a.Genre)
            .WithMany(g=> g.Albums);
            builder.Entity<Album>().HasOne<Singer>(a=> a.Singer)
            .WithMany(s=> s.Albums);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<SongWriter> SongWriters { get; set; }
        public DbSet<MixMaster> MixMasters { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
