﻿// <auto-generated />
using System;
using CarsInfo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarsInfo.Data.Migrations
{
    [DbContext(typeof(CarsInfoDbContext))]
    [Migration("20200109183359_AddedDescriptionAndPricePropOnWheels")]
    partial class AddedDescriptionAndPricePropOnWheels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsInfo.Data.Models.Brakes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Brakes");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.BrakesOrder", b =>
                {
                    b.Property<int>("BrakesId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("BrakesId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("BrakesOrder");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<int>("BrakesId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<int>("EmissionStandard")
                        .HasColumnType("int");

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<double>("MaxWeight")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("SuspensionId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int>("WheelDrive")
                        .HasColumnType("int");

                    b.Property<int>("WheelsId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int?>("YearEnd")
                        .HasColumnType("int");

                    b.Property<int>("YearStart")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrakesId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EngineId");

                    b.HasIndex("ImageId");

                    b.HasIndex("SuspensionId");

                    b.HasIndex("WheelsId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.CarOrder", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("CarOrder");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CompressionRatio")
                        .HasColumnType("float");

                    b.Property<int>("CylindersCount")
                        .HasColumnType("int");

                    b.Property<double>("CylindersDiameter")
                        .HasColumnType("float");

                    b.Property<int>("CylindersPosition")
                        .HasColumnType("int");

                    b.Property<double>("CylindersStroke")
                        .HasColumnType("float");

                    b.Property<int>("FuelInjection")
                        .HasColumnType("int");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("MaxPowerIn")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfValvesPerCylinder")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Torque")
                        .HasColumnType("int");

                    b.Property<int>("Turbine")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.EngineOrder", b =>
                {
                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("EngineId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("EngineOrder");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Suspension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrandMadeFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Suspensions");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.SuspensionOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("SuspensionId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "SuspensionId");

                    b.HasIndex("SuspensionId");

                    b.ToTable("SuspensionOrder");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Wheels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontAxleSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RearAxleSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Wheels");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.WheelsOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("WheelsId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "WheelsId");

                    b.HasIndex("WheelsId");

                    b.ToTable("WheelsOrder");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Brakes", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Image", "Image")
                        .WithMany("Brakes")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CarsInfo.Data.Models.BrakesOrder", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Brakes", "Brakes")
                        .WithMany("Orders")
                        .HasForeignKey("BrakesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Order", "Order")
                        .WithMany("Brakes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Car", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Brakes", "Brakes")
                        .WithMany("Cars")
                        .HasForeignKey("BrakesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Engine", "Engine")
                        .WithMany("Cars")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Image", "Image")
                        .WithMany("Cars")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarsInfo.Data.Models.Suspension", "Suspension")
                        .WithMany("Cars")
                        .HasForeignKey("SuspensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Wheels", "Wheels")
                        .WithMany("Cars")
                        .HasForeignKey("WheelsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.CarOrder", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Order", "Order")
                        .WithMany("Cars")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.EngineOrder", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Engine", "Engine")
                        .WithMany("Orders")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Order", "Order")
                        .WithMany("Engines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Order", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Suspension", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Category", "Category")
                        .WithMany("Suspensions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Image", "Image")
                        .WithMany("Suspensions")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("CarsInfo.Data.Models.SuspensionOrder", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Order", "Order")
                        .WithMany("Suspensions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Suspension", "Suspension")
                        .WithMany("Orders")
                        .HasForeignKey("SuspensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsInfo.Data.Models.Wheels", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Image", "Image")
                        .WithMany("Wheels")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CarsInfo.Data.Models.WheelsOrder", b =>
                {
                    b.HasOne("CarsInfo.Data.Models.Order", "Order")
                        .WithMany("Wheels")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarsInfo.Data.Models.Wheels", "Wheels")
                        .WithMany("Orders")
                        .HasForeignKey("WheelsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
