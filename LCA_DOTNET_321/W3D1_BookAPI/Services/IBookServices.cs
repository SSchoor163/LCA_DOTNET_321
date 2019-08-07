using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace W3D1_BookAPI.Services
{
    public class BoookContext: DbContext
    {
        public DbSet<Book> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo ExecutiveDirectory = new DirectoryInfo(AppContext.BaseDirectory);
            DirectoryInfo ProjectBase = ExecutiveDirectory.Parent.Parent.Parent;
            string DatabaseFile = Path.Combine(ProjectBase.FullName + "Books.db");
            optionsBuilder.UseSqlite("Data Source =" + DatabaseFile);
        }

    }
}
