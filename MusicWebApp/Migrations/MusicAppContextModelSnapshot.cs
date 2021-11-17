﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicWebApp.Areas.Identity.Data;

namespace MusicWebApp.Migrations
{
    [DbContext(typeof(MusicAppContext))]
    partial class MusicAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbumSubject", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("AlbumsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("AlbumSubject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MusicSubject", b =>
                {
                    b.Property<int>("MusicsId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("MusicsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("MusicSubject");
                });

            modelBuilder.Entity("MusicWebApp.Areas.Identity.Data.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MusicWebApp.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SingerArtistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("SingerArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicWebApp.Models.Arrangement", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.ToTable("Arrangement");
                });

            modelBuilder.Entity("MusicWebApp.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicWebApp.Models.Composer", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.ToTable("Composers");
                });

            modelBuilder.Entity("MusicWebApp.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SingerArtistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SingerArtistId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicWebApp.Models.MixMaster", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.ToTable("MixMasters");
                });

            modelBuilder.Entity("MusicWebApp.Models.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("ArrangementArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("ComposerArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("MixMasterArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SingerArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("SongWriterArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url128")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url320")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArrangementArtistId");

                    b.HasIndex("ComposerArtistId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MixMasterArtistId");

                    b.HasIndex("SingerArtistId");

                    b.HasIndex("SongWriterArtistId");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("MusicWebApp.Models.Singer", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.ToTable("Singers");
                });

            modelBuilder.Entity("MusicWebApp.Models.SongWriter", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("NikName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("SongWriters");
                });

            modelBuilder.Entity("MusicWebApp.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("AlbumSubject", b =>
                {
                    b.HasOne("MusicWebApp.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebApp.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MusicWebApp.Areas.Identity.Data.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MusicWebApp.Areas.Identity.Data.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebApp.Areas.Identity.Data.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MusicWebApp.Areas.Identity.Data.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicSubject", b =>
                {
                    b.HasOne("MusicWebApp.Models.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebApp.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicWebApp.Models.Album", b =>
                {
                    b.HasOne("MusicWebApp.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId");

                    b.HasOne("MusicWebApp.Models.Singer", "Singer")
                        .WithMany("Albums")
                        .HasForeignKey("SingerArtistId");

                    b.Navigation("Genre");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("MusicWebApp.Models.Arrangement", b =>
                {
                    b.HasOne("MusicWebApp.Models.Artist", "Artist")
                        .WithOne("Arrangement")
                        .HasForeignKey("MusicWebApp.Models.Arrangement", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicWebApp.Models.Composer", b =>
                {
                    b.HasOne("MusicWebApp.Models.Artist", "Artist")
                        .WithOne("Compos")
                        .HasForeignKey("MusicWebApp.Models.Composer", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicWebApp.Models.Genre", b =>
                {
                    b.HasOne("MusicWebApp.Models.Singer", null)
                        .WithMany("Genres")
                        .HasForeignKey("SingerArtistId");
                });

            modelBuilder.Entity("MusicWebApp.Models.MixMaster", b =>
                {
                    b.HasOne("MusicWebApp.Models.Artist", "Artist")
                        .WithOne("RemixMusics")
                        .HasForeignKey("MusicWebApp.Models.MixMaster", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicWebApp.Models.Music", b =>
                {
                    b.HasOne("MusicWebApp.Models.Album", "Album")
                        .WithMany("Musics")
                        .HasForeignKey("AlbumId");

                    b.HasOne("MusicWebApp.Models.Arrangement", "Arrangement")
                        .WithMany("Arrangements")
                        .HasForeignKey("ArrangementArtistId");

                    b.HasOne("MusicWebApp.Models.Composer", "Composer")
                        .WithMany("Musics")
                        .HasForeignKey("ComposerArtistId");

                    b.HasOne("MusicWebApp.Models.Genre", "Genre")
                        .WithMany("Musics")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWebApp.Models.MixMaster", "MixMaster")
                        .WithMany("RemixMusics")
                        .HasForeignKey("MixMasterArtistId");

                    b.HasOne("MusicWebApp.Models.Singer", "Singer")
                        .WithMany("SingleMusics")
                        .HasForeignKey("SingerArtistId");

                    b.HasOne("MusicWebApp.Models.SongWriter", "SongWriter")
                        .WithMany("Lyrics")
                        .HasForeignKey("SongWriterArtistId");

                    b.Navigation("Album");

                    b.Navigation("Arrangement");

                    b.Navigation("Composer");

                    b.Navigation("Genre");

                    b.Navigation("MixMaster");

                    b.Navigation("Singer");

                    b.Navigation("SongWriter");
                });

            modelBuilder.Entity("MusicWebApp.Models.Singer", b =>
                {
                    b.HasOne("MusicWebApp.Models.Artist", "Artist")
                        .WithOne("Singer")
                        .HasForeignKey("MusicWebApp.Models.Singer", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicWebApp.Models.SongWriter", b =>
                {
                    b.HasOne("MusicWebApp.Models.Artist", "Artist")
                        .WithOne("SongWriter")
                        .HasForeignKey("MusicWebApp.Models.SongWriter", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicWebApp.Models.Album", b =>
                {
                    b.Navigation("Musics");
                });

            modelBuilder.Entity("MusicWebApp.Models.Arrangement", b =>
                {
                    b.Navigation("Arrangements");
                });

            modelBuilder.Entity("MusicWebApp.Models.Artist", b =>
                {
                    b.Navigation("Arrangement");

                    b.Navigation("Compos");

                    b.Navigation("RemixMusics");

                    b.Navigation("Singer");

                    b.Navigation("SongWriter");
                });

            modelBuilder.Entity("MusicWebApp.Models.Composer", b =>
                {
                    b.Navigation("Musics");
                });

            modelBuilder.Entity("MusicWebApp.Models.Genre", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Musics");
                });

            modelBuilder.Entity("MusicWebApp.Models.MixMaster", b =>
                {
                    b.Navigation("RemixMusics");
                });

            modelBuilder.Entity("MusicWebApp.Models.Singer", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Genres");

                    b.Navigation("SingleMusics");
                });

            modelBuilder.Entity("MusicWebApp.Models.SongWriter", b =>
                {
                    b.Navigation("Lyrics");
                });
#pragma warning restore 612, 618
        }
    }
}
