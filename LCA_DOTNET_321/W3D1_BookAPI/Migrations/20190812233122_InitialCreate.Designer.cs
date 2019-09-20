﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W3D1_BookAPI.Data;

namespace W3D1_BookAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20190812233122_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("W3D1_BookAPI.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1948, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Terry",
                            LastName = "Goodkind"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Isaac",
                            LastName = "Asimov"
                        });
                });

            modelBuilder.Entity("W3D1_BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<string>("OriginalLanguage")
                        .IsRequired();

                    b.Property<int>("PublicationYear");

                    b.Property<int>("PublisherId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Genre = "Fantasy",
                            OriginalLanguage = "English",
                            PublicationYear = 1996,
                            PublisherId = 1,
                            Title = "The Stone of Tears"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Genre = "Fantasy",
                            OriginalLanguage = "English",
                            PublicationYear = 1994,
                            PublisherId = 1,
                            Title = "Wizard's First Rule"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Genre = "Scifi",
                            OriginalLanguage = "English",
                            PublicationYear = 1951,
                            PublisherId = 2,
                            Title = "Foundation"
                        });
                });

            modelBuilder.Entity("W3D1_BookAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired();

                    b.Property<int>("FoundedYear");

                    b.Property<string>("HeadQuartersLocation")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryOfOrigin = "United States",
                            FoundedYear = 1980,
                            HeadQuartersLocation = "New York, NY",
                            Name = "Tor Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            CountryOfOrigin = "United States",
                            FoundedYear = 1948,
                            HeadQuartersLocation = "New York, Ny",
                            Name = "Gnome Press"
                        });
                });

            modelBuilder.Entity("W3D1_BookAPI.Models.Book", b =>
                {
                    b.HasOne("W3D1_BookAPI.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("W3D1_BookAPI.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}