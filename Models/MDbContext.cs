using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.Models
{
    public class MDbContext : DbContext
    {
        public MDbContext()
        {

        }
        public MDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicLabel>(opt =>
            {
                opt.HasKey(e => e.IdMusicLabel);
                opt.Property(e => e.IdMusicLabel).ValueGeneratedOnAdd();

                opt.Property(e => e.Name).IsRequired().HasMaxLength(50);

                opt.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "MusicLabel1" },
                    new MusicLabel { IdMusicLabel = 2, Name = "MusicLabel2" }
                );
            });

            modelBuilder.Entity<Musician>(opt =>
            {
                opt.HasKey(e => e.IdMusician);
                opt.Property(e => e.IdMusician).ValueGeneratedOnAdd();

                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                opt.Property(e => e.NickName).IsRequired().HasMaxLength(20);

                opt.HasData(
                    new Musician { IdMusician = 1, FirstName = "Musician1", LastName = "xxx", NickName = "xx" },
                    new Musician { IdMusician = 2, FirstName = "Musician2", LastName = "xxx", NickName = "xx" }
                );
            });

            modelBuilder.Entity<Album>(opt =>
            {
                opt.HasKey(e => e.IdAlbum);
                opt.Property(e => e.IdAlbum).ValueGeneratedOnAdd();

                opt.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);

                opt.HasOne(e => e.MusicLabel)
                    .WithMany(s => s.Albums)
                    .HasForeignKey(s => s.IdMusicLabel);

                opt.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Album1", PublishDate = DateTime.Now, IdMusicLabel = 1 },
                    new Album { IdAlbum = 2, AlbumName = "Album2", PublishDate = DateTime.Now, IdMusicLabel = 2 }
                );
            });

            modelBuilder.Entity<Track>(opt =>
            {
                opt.HasKey(e => e.IdTrack);
                opt.Property(e => e.IdTrack).ValueGeneratedOnAdd();

                opt.Property(e => e.TrackName).IsRequired().HasMaxLength(20);

                opt.HasOne(e => e.Album)
                    .WithMany(s => s.Tracks)
                    .HasForeignKey(s => s.IdMusicAlbum);

                opt.HasData(
                    new Track { IdTrack = 1, TrackName = "Track1", Duration = 22, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "Track2", Duration = 22, IdMusicAlbum = 2 }
                );
            });

            modelBuilder.Entity<Musician_Track>(opt =>
            {
                opt.HasKey(t => new { t.IdTrack, t.IdMusician });
                opt.Property(e => e.IdTrack).ValueGeneratedOnAdd();
                opt.Property(e => e.IdMusician).ValueGeneratedOnAdd();

                opt.HasOne(e => e.Track)
                    .WithMany(s => s.Musician_Tracks)
                    .HasForeignKey(s => s.IdTrack);

                opt.HasOne(e => e.Musician)
                    .WithMany(s => s.Musician_Tracks)
                    .HasForeignKey(s => s.IdMusician);

                opt.HasData(
                    new Musician_Track { IdTrack = 1, IdMusician = 1 },
                    new Musician_Track { IdTrack = 2, IdMusician = 2 }
                );
            });


        }
    }
}
