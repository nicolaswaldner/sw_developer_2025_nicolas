using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Persistence.Repositories.DBContext
{
    public class MovieDbContext : DbContext
    {
        //EF Migration erstellen über die Package Manager Console:
        //Add-Migration InitialCreate -Context MovieDbContext -startupProject SD.Persistence
        //Update-Database -Context MovieDbContext

        //Alternativ über .NET CLI:
        //dotnet ef migration add InitialCreate --context MovieDbContext --startup-project SD.Persistence
        //dotnet ef databse update --context MovieDbContext --startup-project SD_Persistence
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(90);
        }

        //Alles was wir abfragen bei DB wird hier von DbSet geholt
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MediumType> MediumTypes { get; set; }

        //Fluent API Konfiguration für die Entitäten, wird als letztes ausgeführt, überschreibt
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity => //mit lamda expression auf entity zugriff bekommen
            {
                entity.ToTable(nameof(Movie) + "s");
                //entity.HasKey(e => e.Id); //reduntant, weil ef core automatisch die id-eigenschaft als primärschlüssel erkennt
                entity.Property(p => p.Title).HasMaxLength(128).IsRequired();
                entity.Property(p => p.ReleaseDate).HasColumnType("date");
                entity.Property(p => p.Price).HasPrecision(18, 2).HasDefaultValue(0M);

                entity.HasIndex(i => i.Title).HasDatabaseName("IX_" + nameof(Movie) + "s_" + nameof(Movie.Title));
                entity.HasIndex(i => i.GenreId).HasDatabaseName("IX_" + nameof(Movie) + "s_" + nameof(Movie.GenreId));
                entity.HasIndex(i => i.MediumTypeCode).HasDatabaseName("IX_" + nameof(Movie) + "s_" + nameof(Movie.MediumTypeCode));

                //Beziehungen und Navigationseigenschaften
                entity.HasOne(m => m.MediumType)
                .WithMany(mt => mt.Movies)
                .HasForeignKey(m => m.MediumTypeCode)
                .OnDelete(DeleteBehavior.SetNull); //beim löschen eines MediumType werden die zugehörigen Filme nicht gelöscht
                                                   //sondern die MediumTypeCode-Fremdschlüssel auf NULL gesetzt

                entity.HasOne(m => m.Genre)
                 .WithMany(mt => mt.Movies)
                 .HasForeignKey(m => m.GenreId)
                 .OnDelete(DeleteBehavior.Restrict); //Genre kann nicht gelöscht werden, solange es Filme gibt,
                                                     //die diesem Genre zugeordnet sind => Referntielle Integrität
            }  
            );

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable(nameof(Genre) + "s");
                entity.Property(p => p.Name).HasMaxLength(64).IsRequired();
                //redundant, da ef core automatisch id-eigenschaft als primärschlüssel erkennt
            }
            );

            //Seed Methode zum Vorbefüllen der Datenbank mit Testdaten bzw. Stammdaten

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action"},
                new Genre { Id = 2, Name = "Comedy"},
                new Genre { Id = 3, Name = "Drama"},
                new Genre { Id = 4, Name = "Horror"},
                new Genre { Id = 5, Name = "Science Fiction"}
            );

            modelBuilder.Entity<MediumType>().HasData(
                new MediumType { Code = "CD", Name = "Compact Disc" },
                new MediumType { Code = "DVD", Name = "Digital Versatile Disc" },
                new MediumType { Code = "BD", Name = "Blu-ray Disc" },
                new MediumType { Code = "VHS", Name = "Video Home System" },
                new MediumType { Code = "STREAM", Name = "Streaming" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Title = "Die Hard", GenreId = 1, MediumTypeCode = "DVD", Price = 9.99M, ReleaseDate = new DateTime(1988, 7, 15), Rating = Ratings.Excellent },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Title = "Mad Max: Fury Road", GenreId = 1, MediumTypeCode = "BD", Price = 14.99M, ReleaseDate = new DateTime(2015, 5, 15), Rating = Ratings.Masterpiece },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Title = "Groundhog Day", GenreId = 2, MediumTypeCode = "DVD", Price = 7.99M, ReleaseDate = new DateTime(1993, 2, 12), Rating = Ratings.Good },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Title = "The Grand Budapest Hotel", GenreId = 2, MediumTypeCode = "BD", Price = 12.99M, ReleaseDate = new DateTime(2014, 3, 28), Rating = Ratings.Bad },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Title = "The Shawshank Redemption", GenreId = 3, MediumTypeCode = "DVD", Price = 8.99M, ReleaseDate = new DateTime(1994, 9, 23), Rating = Ratings.Masterpiece },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Title = "Forrest Gump", GenreId = 3, MediumTypeCode = "BD", Price = 11.99M, ReleaseDate = new DateTime(1994, 7, 6), Rating = Ratings.Excellent },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Title = "The Shining", GenreId = 4, MediumTypeCode = "DVD", Price = 9.99M, ReleaseDate = new DateTime(1980, 5, 23), Rating = Ratings.Excellent },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Title = "A Quiet Place", GenreId = 4, MediumTypeCode = "STREAM", Price = 4.99M, ReleaseDate = new DateTime(2018, 4, 6), Rating = Ratings.Good },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Title = "Blade Runner", GenreId = 5, MediumTypeCode = "BD", Price = 13.99M, ReleaseDate = new DateTime(1982, 6, 25), Rating = Ratings.Bad },
                new Movie { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Title = "The Matrix", GenreId = 5, MediumTypeCode = "DVD", Price = 10.99M, ReleaseDate = new DateTime(1999, 3, 31), Rating = Ratings.Masterpiece }
            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

#if DEBUG
            if(currentDirectory.IndexOf("bin") > -1)
            {
                currentDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("bin"));
            }
#endif

            var configurationBuilder = new ConfigurationBuilder().SetBasePath(currentDirectory)
                                                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("MovieDbContext");

            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout(90));

        }
    }
}
