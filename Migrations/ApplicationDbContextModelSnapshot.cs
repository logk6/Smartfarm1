﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smartfarm1.Models;

#nullable disable

namespace Smartfarm1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Smartfarm1.Models.FarmStatus", b =>
                {
                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CO2")
                        .HasColumnType("int");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<int>("Light_0x5C")
                        .HasColumnType("int");

                    b.Property<int>("SFID")
                        .HasColumnType("int");

                    b.Property<int>("SoilMoisture")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("DateTime");

                    b.ToTable("FarmStatus");
                });

            modelBuilder.Entity("Smartfarm1.Models.FarmStatusNow", b =>
                {
                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CO2")
                        .HasColumnType("int");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<int>("Light_0x5C")
                        .HasColumnType("int");

                    b.Property<int>("SFID")
                        .HasColumnType("int");

                    b.Property<int>("SoilMoisture")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("DateTime");

                    b.ToTable("FarmStatusNow");
                });

            modelBuilder.Entity("Smartfarm1.Models.Smartfarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Smartfarm");
                });
#pragma warning restore 612, 618
        }
    }
}
