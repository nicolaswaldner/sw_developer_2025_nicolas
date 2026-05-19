using Microsoft.EntityFrameworkCore;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Data
{
    public class AppDbContext :DbContext
    {
        //Eigenschaften/Properties
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MeasuredData> MeasuredData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) //hierdurch wird Konstruktor von DbContext aufgerufen
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //nur dann notwendig, wenn Tabellenname nicht Klassennamen entspricht (in unserem Fall hat es den gleichen Namen)
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<MeasuredData>().ToTable("MeasuredData");

        }



    }
}
