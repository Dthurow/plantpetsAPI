using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace plantpetsAPI.Models
{
    public partial class PlantPetsContext : DbContext
    {
        public PlantPetsContext()
        {
        }

        public PlantPetsContext(DbContextOptions<PlantPetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alerts> Alerts { get; set; }
        public virtual DbSet<PersonPlants> PersonPlants { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Plants> Plants { get; set; }
        public virtual DbSet<WaterLogs> WaterLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerts>(entity =>
            {
                entity.HasKey(e => e.AlertId);

                entity.Property(e => e.AlertTime).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Alerts__PersonId__4222D4EF");

                entity.HasOne(d => d.PersonPlant)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.PersonPlantId)
                    .HasConstraintName("FK__Alerts__PersonPl__4316F928");
            });

            modelBuilder.Entity<PersonPlants>(entity =>
            {
                entity.HasKey(e => e.PersonPlantId);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPlants)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__PersonPla__Perso__3F466844");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.PersonPlants)
                    .HasForeignKey(d => d.PlantId)
                    .HasConstraintName("FK__PersonPla__Plant__3E52440B");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Plants>(entity =>
            {
                entity.HasKey(e => e.PlantId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WaterLogs>(entity =>
            {
                entity.Property(e => e.WaterTime).HasColumnType("datetime");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.WaterLogs)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__WaterLogs__Perso__45F365D3");

                entity.HasOne(d => d.PersonPlant)
                    .WithMany(p => p.WaterLogs)
                    .HasForeignKey(d => d.PersonPlantId)
                    .HasConstraintName("FK__WaterLogs__Perso__46E78A0C");
            });
        }
    }
}
