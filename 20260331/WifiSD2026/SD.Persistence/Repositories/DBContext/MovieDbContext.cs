using Microsoft.EntityFrameworkCore;
using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Persistence.Repositories.DBContext
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(90);
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MediumType> MediumTypes { get; set; }

        //Fluent API Konfiguration für die Entitäten, wird als letztes ausgeführt, überschreibt
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
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



        }
    }
}
