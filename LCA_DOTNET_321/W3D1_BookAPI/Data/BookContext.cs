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
                    Author = "Terry Goodkind",
                    Category = "Fantasy",
                    Title = "The Stone of Tears"
                },
                new Book
                {
                    Id = 2,
                    Author = "Charles Darwin",
                    Title = "The Origin of Species",
                    Category = "Science"
                }

                );

        }

    }
}
