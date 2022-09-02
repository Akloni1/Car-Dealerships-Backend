using CarDealerships.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarDealerships.Data
{
    public partial class CarDealershipsContext : DbContext
    {
        public CarDealershipsContext()
        {
        }

        public CarDealershipsContext(DbContextOptions<CarDealershipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarDealership> CarDealerships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JUI9V07;Database=CarDealerships;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<CarDealership>(entity =>
            {
                entity.HasKey(e => e.IdCarDealership);

                entity.ToTable("CarDealership");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.IdCar);

                entity.ToTable("Car");

                entity.Property(e => e.Stamp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasOne(d => d.CarDealership)
                   .WithMany(p => p.Cars)
                   .HasForeignKey(d => d.IdCarDealership)
                   .HasConstraintName("FK_Car_CarDealership");
            });




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);




    }
}
