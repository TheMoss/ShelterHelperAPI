﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShelterHelperAPI.Models;

#nullable disable

namespace ShelterHelperAPI.Migrations
{
    [DbContext(typeof(ShelterContext))]
    [Migration("20240709172051_AddOwnerTable")]
    partial class AddOwnerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShelterHelperAPI.Models.Accessory", b =>
                {
                    b.Property<int?>("AccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("AccessoryId"));

                    b.Property<string>("AccessoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("AccessoryId");

                    b.ToTable("Accessory");

                    b.HasData(
                        new
                        {
                            AccessoryId = 1,
                            AccessoryName = "collar",
                            Quantity = 14
                        },
                        new
                        {
                            AccessoryId = 2,
                            AccessoryName = "halter",
                            Quantity = 7
                        },
                        new
                        {
                            AccessoryId = 3,
                            AccessoryName = "brush",
                            Quantity = 15
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Animal", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateOnly>("AdmissionDay")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("AdoptionDay")
                        .HasColumnType("date");

                    b.Property<int>("ChipNumber")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Health")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("AnimalsDb");
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Bedding", b =>
                {
                    b.Property<int?>("BeddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("BeddingId"));

                    b.Property<string>("BeddingName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity_kg")
                        .HasColumnType("integer");

                    b.HasKey("BeddingId");

                    b.ToTable("Bedding");

                    b.HasData(
                        new
                        {
                            BeddingId = 1,
                            BeddingName = "blanket",
                            Quantity_kg = 9
                        },
                        new
                        {
                            BeddingId = 2,
                            BeddingName = "straw",
                            Quantity_kg = 143
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Diet", b =>
                {
                    b.Property<int?>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("DietId"));

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity_kg")
                        .HasColumnType("integer");

                    b.HasKey("DietId");

                    b.ToTable("Diet");

                    b.HasData(
                        new
                        {
                            DietId = 1,
                            DietName = "dog food",
                            Quantity_kg = 157
                        },
                        new
                        {
                            DietId = 2,
                            DietName = "hay",
                            Quantity_kg = 452
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeePersonalId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeName = "Steve Wazowski",
                            EmployeePersonalId = 840792
                        },
                        new
                        {
                            EmployeeId = 2,
                            EmployeeName = "Lee Smith",
                            EmployeePersonalId = 625614
                        },
                        new
                        {
                            EmployeeId = 3,
                            EmployeeName = "Jill Jackson",
                            EmployeePersonalId = 739618
                        },
                        new
                        {
                            EmployeeId = 4,
                            EmployeeName = "Sophie Brown",
                            EmployeePersonalId = 857104
                        },
                        new
                        {
                            EmployeeId = 5,
                            EmployeeName = "Arnold Mason",
                            EmployeePersonalId = 629513
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OwnerId");

                    b.ToTable("Owner");

                    b.HasData(
                        new
                        {
                            OwnerId = 1,
                            Address = "Park Road 7, Sydney",
                            OwnerName = "Amanda Lawson"
                        },
                        new
                        {
                            OwnerId = 2,
                            Address = "Sausage Plaza 17, Pinewood",
                            OwnerName = "Guy Brickman"
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Species", b =>
                {
                    b.Property<int?>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("SpeciesId"));

                    b.Property<int>("AccessoryId")
                        .HasColumnType("integer");

                    b.Property<int>("BeddingId")
                        .HasColumnType("integer");

                    b.Property<int>("DietId")
                        .HasColumnType("integer");

                    b.Property<string>("SpeciesName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ToyId")
                        .HasColumnType("integer");

                    b.HasKey("SpeciesId");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("BeddingId");

                    b.HasIndex("DietId");

                    b.HasIndex("ToyId");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            SpeciesId = 1,
                            AccessoryId = 1,
                            BeddingId = 1,
                            DietId = 1,
                            SpeciesName = "dog",
                            ToyId = 1
                        },
                        new
                        {
                            SpeciesId = 2,
                            AccessoryId = 2,
                            BeddingId = 2,
                            DietId = 2,
                            SpeciesName = "cow",
                            ToyId = 2
                        },
                        new
                        {
                            SpeciesId = 3,
                            AccessoryId = 3,
                            BeddingId = 2,
                            DietId = 2,
                            SpeciesName = "horse",
                            ToyId = 3
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Toy", b =>
                {
                    b.Property<int?>("ToyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("ToyId"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("ToyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ToyId");

                    b.ToTable("Toy");

                    b.HasData(
                        new
                        {
                            ToyId = 1,
                            Quantity = 20,
                            ToyName = "ball"
                        },
                        new
                        {
                            ToyId = 2,
                            Quantity = 5,
                            ToyName = "salt block"
                        },
                        new
                        {
                            ToyId = 3,
                            Quantity = 3,
                            ToyName = "big ball"
                        });
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Animal", b =>
                {
                    b.HasOne("ShelterHelperAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShelterHelperAPI.Models.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("ShelterHelperAPI.Models.Species", b =>
                {
                    b.HasOne("ShelterHelperAPI.Models.Accessory", "Accessory")
                        .WithMany()
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShelterHelperAPI.Models.Bedding", "Bedding")
                        .WithMany()
                        .HasForeignKey("BeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShelterHelperAPI.Models.Diet", "Diet")
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShelterHelperAPI.Models.Toy", "Toy")
                        .WithMany()
                        .HasForeignKey("ToyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessory");

                    b.Navigation("Bedding");

                    b.Navigation("Diet");

                    b.Navigation("Toy");
                });
#pragma warning restore 612, 618
        }
    }
}