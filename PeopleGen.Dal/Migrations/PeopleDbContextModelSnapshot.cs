﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PeopleGen.Dal;

namespace PeopleGen.Dal.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    partial class PeopleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PeopleGen.Core.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("BusinessOwnerPersonId")
                        .HasColumnType("integer");

                    b.Property<string>("BusinessType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int?>("CivilizationCityId")
                        .HasColumnType("integer");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<int>("NumOfEmployees")
                        .HasColumnType("integer");

                    b.HasKey("BusinessId");

                    b.HasIndex("BusinessOwnerPersonId");

                    b.HasIndex("CivilizationCityId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("PeopleGen.Core.Civilization", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ideology")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeOfRule")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CityId");

                    b.ToTable("Civilization");
                });

            modelBuilder.Entity("PeopleGen.Core.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("InventoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InventoryType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCursed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMagical")
                        .HasColumnType("boolean");

                    b.Property<string>("MoneyType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("PeopleGen.Core.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Alignment")
                        .HasColumnType("text");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PeopleGen.Core.Species", b =>
                {
                    b.Property<int>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SpeciesName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SpeciesId");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            SpeciesId = 1,
                            SpeciesName = "Elf"
                        },
                        new
                        {
                            SpeciesId = 2,
                            SpeciesName = "Human"
                        },
                        new
                        {
                            SpeciesId = 3,
                            SpeciesName = "Orc"
                        });
                });

            modelBuilder.Entity("PeopleGen.Core.Business", b =>
                {
                    b.HasOne("PeopleGen.Core.Person", "BusinessOwner")
                        .WithMany()
                        .HasForeignKey("BusinessOwnerPersonId");

                    b.HasOne("PeopleGen.Core.Civilization", "Civilization")
                        .WithMany()
                        .HasForeignKey("CivilizationCityId");

                    b.HasOne("PeopleGen.Core.Inventory", null)
                        .WithMany("business")
                        .HasForeignKey("InventoryId");

                    b.Navigation("BusinessOwner");

                    b.Navigation("Civilization");
                });

            modelBuilder.Entity("PeopleGen.Core.Person", b =>
                {
                    b.HasOne("PeopleGen.Core.Civilization", "City")
                        .WithMany("Population")
                        .HasForeignKey("CityId");

                    b.HasOne("PeopleGen.Core.Species", "Species")
                        .WithMany("persons")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PeopleGen.Core.Civilization", b =>
                {
                    b.Navigation("Population");
                });

            modelBuilder.Entity("PeopleGen.Core.Inventory", b =>
                {
                    b.Navigation("business");
                });

            modelBuilder.Entity("PeopleGen.Core.Species", b =>
                {
                    b.Navigation("persons");
                });
#pragma warning restore 612, 618
        }
    }
}
