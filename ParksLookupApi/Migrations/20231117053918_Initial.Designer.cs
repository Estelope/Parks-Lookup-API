﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkLookupApi.Models;

#nullable disable

namespace ParksLookupApi.Migrations
{
    [DbContext(typeof(ParkLookupApiContext))]
    [Migration("20231117053918_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkLookupApi.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Climate")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Climate = "subarctic",
                            Location = "United States",
                            Name = "Yellowstone National Park"
                        },
                        new
                        {
                            ParkId = 2,
                            Climate = "subarctic",
                            Location = "Canada",
                            Name = "Banff National Park"
                        },
                        new
                        {
                            ParkId = 3,
                            Climate = "subtropical",
                            Location = "South Africa",
                            Name = "Kruger National Park"
                        },
                        new
                        {
                            ParkId = 4,
                            Climate = "mediterranean",
                            Location = "United States",
                            Name = "Yosemites National Park"
                        },
                        new
                        {
                            ParkId = 5,
                            Climate = "temperate",
                            Location = "Chile",
                            Name = "Torres del Paine National Park"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
