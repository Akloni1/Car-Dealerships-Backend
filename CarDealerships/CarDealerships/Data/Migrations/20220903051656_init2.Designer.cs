﻿// <auto-generated />
using CarDealerships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarDealerships.Data.Migrations
{
    [DbContext(typeof(CarDealershipsContext))]
    [Migration("20220903051656_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarDealerships.Models.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdCarDealership")
                        .HasColumnType("int");

                    b.Property<string>("Stamp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCar");

                    b.HasIndex("IdCarDealership");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("CarDealerships.Models.CarDealership", b =>
                {
                    b.Property<int>("IdCarDealership")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarDealership"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCarDealership");

                    b.ToTable("CarDealership", (string)null);
                });

            modelBuilder.Entity("CarDealerships.Models.Car", b =>
                {
                    b.HasOne("CarDealerships.Models.CarDealership", "CarDealership")
                        .WithMany("Cars")
                        .HasForeignKey("IdCarDealership")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Car_CarDealership");

                    b.Navigation("CarDealership");
                });

            modelBuilder.Entity("CarDealerships.Models.CarDealership", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
