﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsTestApp.Data;

#nullable disable

namespace StarWarsTestApp.Migrations
{
    [DbContext(typeof(StarWarsDbContext))]
    [Migration("20230622141501_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColorOfEyes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ColorOfHair")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Growth")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Planet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.CharacterFilms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("FilmId");

                    b.ToTable("CharactersFilms");
                });

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.CharacterFilms", b =>
                {
                    b.HasOne("StarWarsTestApp.Data.Entities.Character", "Character")
                        .WithMany("CharacterFilms")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWarsTestApp.Data.Entities.Film", "Film")
                        .WithMany("CharacterFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.Character", b =>
                {
                    b.Navigation("CharacterFilms");
                });

            modelBuilder.Entity("StarWarsTestApp.Data.Entities.Film", b =>
                {
                    b.Navigation("CharacterFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
