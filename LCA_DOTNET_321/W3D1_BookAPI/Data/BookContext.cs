using System;
using Microsoft.EntityFrameworkCore;
using W3D1_BookAPI.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        //local DB copy
        public DbSet<Book> Books { get; set; } 
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        //Database link
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;
            string DatabaseFile = Path.Combine(ProjectBase.FullName, "Book.db");
            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }

        //This method runs once when the DbContext is first used. It's a place we can customize how EF core maps our model to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Genre = "Fantasy",
                    Title = "The Stone of Tears",
                    OriginalLanguage = "English",
                    PublicationYear = 1996,
                    AuthorId = 1,
                    PublisherId = 1
                },
                new Book {
                    Id = 2,
                    Genre = "Fantasy",
                    Title = "Wizard's First Rule",
                    OriginalLanguage = "English",
                    PublicationYear = 1994,
                    AuthorId = 1,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 3, 
                    Title = "Foundation",
                    Genre = "Scifi",
                    OriginalLanguage = "English",
                    PublicationYear = 1951,
                    PublisherId = 2,
                    AuthorId = 2
                }

                );
            modelBuilder.Entity<Author>().HasData(

                new Author
                {
                    Id = 1,
                    FirstName = "Terry",
                    LastName = "Goodkind",
                    BirthDate = new DateTime(1948, 5, 1),
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Isaac",
                    LastName = "Asimov",
                    BirthDate = new DateTime(1920, 1, 2),
                }

                ) ;
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Tor Fantasy",
                    CountryOfOrigin = "United States",
                    HeadQuartersLocation = "New York, NY",
                    FoundedYear = 1980
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Gnome Press",
                    CountryOfOrigin = "United States",
                    FoundedYear = 1948,
                    HeadQuartersLocation = "New York, Ny"
                }

            );

        }

    }
}
